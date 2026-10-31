using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.DTOs;
using MiniSupermarket.API.Models;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSupermarket.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context) {
            _context = context;
        }

        // 1. GET: Lấy danh sách sản phẩm kèm tên nhóm hàng (Hỗ trợ lọc theo CategoryId và phân trang .Skip().Take())
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? categoryId = null, [FromQuery] int? page = null, [FromQuery] int? pageSize = null) {
            var query = _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .AsQueryable();

            // Lọc theo nhóm hàng nếu có truyền categoryId
            if (categoryId.HasValue && categoryId.Value > 0) {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            query = query.OrderBy(p => p.ProductId);

            // Phân trang dữ liệu máy chủ bằng cặp lệnh LINQ .Skip() và .Take()
            int currentPage = page.HasValue && page.Value > 0 ? page.Value : 1;
            int currentSize = pageSize.HasValue && pageSize.Value > 0 ? pageSize.Value : 1000;
            query = query.Skip((currentPage - 1) * currentSize).Take(currentSize);

            var list = await query
                .Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                })
                .ToListAsync();

            return Ok(list);
        }

        // 1b. GET: API Phân trang chuyên biệt trên Server bằng LINQ .Skip() và .Take()
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] int? categoryId = null,
            [FromQuery] string? keyword = null) {

            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var query = _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .AsQueryable();

            if (categoryId.HasValue && categoryId.Value > 0) {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword)) {
                string kw = keyword.Trim();
                query = query.Where(p => p.ProductName.Contains(kw) ||
                                         p.Barcode.Contains(kw));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                })
                .ToListAsync();

            return Ok(new PagedResultDto<ProductDto> {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            });
        }

        // 2. GET: Lấy chi tiết sản phẩm theo ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) {
            var p = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(x => x.ProductId == id);

            if (p == null) {
                return NotFound(new { message = "Không tìm thấy sản phẩm trong CSDL!" });
            }

            return Ok(new ProductDto {
                ProductId = p.ProductId,
                Barcode = p.Barcode,
                ProductName = p.ProductName,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
            });
        }

        // 2b. GET: Tra cứu Barcode bằng ADO.NET thuần (Tiêu chí 32 & 33: SqlConnection, SqlCommand, SqlDataReader, AddWithValue chống SQL Injection)
        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetByBarcode(string barcode) {
            if (string.IsNullOrWhiteSpace(barcode)) {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            var connString = _context.Database.GetConnectionString();
            if (string.IsNullOrEmpty(connString)) {
                return StatusCode(500, new { message = "Không tìm thấy chuỗi kết nối cơ sở dữ liệu!" });
            }

            // Tiêu chí 32 & 33: Dùng ADO.NET SqlConnection + SqlCommand với truy vấn tối ưu
            const string querySql = @"
                SELECT p.ProductId, p.Barcode, p.ProductName, p.Price, p.StockQuantity, p.CategoryId,
                       ISNULL(c.CategoryName, N'Không xác định') AS CategoryName
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
                WHERE p.Barcode = @Barcode";

            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            await using var cmd = new SqlCommand(querySql, conn);
            // Tiêu chí 33: Sử dụng cmd.Parameters.AddWithValue cho tham số truyền vào, chống SQL Injection, tuyệt đối không cộng chuỗi
            cmd.Parameters.AddWithValue("@Barcode", barcode.Trim());

            // Tiêu chí 33: Dùng SqlDataReader duyệt dữ liệu một chiều siêu tốc và bọc trong khối using an toàn
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync()) {
                var productDto = new ProductDto {
                    ProductId = reader.GetInt32(0),
                    Barcode = reader.GetString(1),
                    ProductName = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    StockQuantity = reader.GetInt32(4),
                    CategoryId = reader.GetInt32(5),
                    CategoryName = reader.GetString(6)
                };
                return Ok(productDto);
            }

            return NotFound(new { message = "Không tìm thấy sản phẩm có mã vạch này!" });
        }

        // 3. SEARCH & FILTER (Tiêu chí 24): Tìm kiếm tên sản phẩm gần đúng bằng LINQ (.Contains) kết hợp lọc theo Nhóm hàng (CategoryId)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? keyword = null, [FromQuery] int? categoryId = null) {
            var query = _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .AsQueryable();

            if (categoryId.HasValue && categoryId.Value > 0) {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(keyword)) {
                string kw = keyword.Trim();
                // Tìm kiếm tên sản phẩm gần đúng bằng LINQ .Contains()
                var directMatches = await query
                    .Where(p => p.ProductName.Contains(kw) || p.Barcode.Contains(kw))
                    .Select(p => new ProductDto {
                        ProductId = p.ProductId,
                        Barcode = p.Barcode,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        StockQuantity = p.StockQuantity,
                        CategoryId = p.CategoryId,
                        CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                    })
                    .ToListAsync();

                // Nếu gõ không dấu (VD: "banh", "sua", "kinh mat") thì hỗ trợ so khớp bỏ dấu tiếng Việt
                if (directMatches.Count == 0) {
                    var allInCategory = await query
                        .Select(p => new ProductDto {
                            ProductId = p.ProductId,
                            Barcode = p.Barcode,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            StockQuantity = p.StockQuantity,
                            CategoryId = p.CategoryId,
                            CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                        })
                        .ToListAsync();

                    string kwUnsigned = RemoveDiacritics(kw);
                    directMatches = allInCategory
                        .Where(p => p.ProductName.Contains(kw, StringComparison.OrdinalIgnoreCase) ||
                                    RemoveDiacritics(p.ProductName).Contains(kwUnsigned, StringComparison.OrdinalIgnoreCase) ||
                                    p.Barcode.Contains(kw, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                // Ưu tiên các sản phẩm có chữ bắt đầu bằng từ khóa (VD: gõ "bánh" sẽ ưu tiên "Bánh..." lên đầu tiên)
                string kwNorm = RemoveDiacritics(kw);
                var ordered = directMatches
                    .OrderByDescending(p => p.ProductName.StartsWith(kw, StringComparison.OrdinalIgnoreCase) ||
                                            RemoveDiacritics(p.ProductName).StartsWith(kwNorm, StringComparison.OrdinalIgnoreCase))
                    .ThenBy(p => p.ProductId)
                    .ToList();

                return Ok(ordered);
            }

            var result = await query
                .OrderBy(p => p.ProductId)
                .Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                })
                .ToListAsync();

            return Ok(result);
        }

        private static string RemoveDiacritics(string text) {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized) {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd').Replace('Đ', 'D');
        }

        // 4. POST: Thêm mới sản phẩm qua SaveProductDto (Admin & Warehouse)
        [HttpPost]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Create([FromBody] SaveProductDto dto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var newProduct = new Product {
                Barcode = dto.Barcode,
                ProductName = dto.ProductName,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            var category = await _context.Categories.FindAsync(newProduct.CategoryId);
            var responseDto = new ProductDto {
                ProductId = newProduct.ProductId,
                Barcode = newProduct.Barcode,
                ProductName = newProduct.ProductName,
                Price = newProduct.Price,
                StockQuantity = newProduct.StockQuantity,
                CategoryId = newProduct.CategoryId,
                CategoryName = category?.CategoryName ?? "Không xác định"
            };

            return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, responseDto);
        }

        // 5. PUT: Cập nhật thông tin sản phẩm qua SaveProductDto (Admin & Warehouse)
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Warehouse")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveProductDto updateDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần cập nhật!" });
            }

            product.Barcode = updateDto.Barcode;
            product.ProductName = updateDto.ProductName;
            product.Price = updateDto.Price;
            product.StockQuantity = updateDto.StockQuantity;
            product.CategoryId = updateDto.CategoryId;

            await _context.SaveChangesAsync();
            return Ok(updateDto);
        }

        // 6. DELETE: Xóa sản phẩm (Chỉ Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa!" });
            }

            _context.Customers.AsNoTracking();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Đã xóa sản phẩm thành công!", deletedId = id });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
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

        // 1. GET: Lấy toàn bộ danh sách sản phẩm kèm tên nhóm hàng
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var list = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                })
                .OrderBy(p => p.ProductId)
                .ToListAsync();

            return Ok(list);
        }

        // 2. GET: Lấy chi tiết sản phẩm theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var p = await _context.Products
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

        // 3. SEARCH: Tìm kiếm sản phẩm theo Tên sản phẩm, Mã vạch hoặc Nhóm hàng
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword) {
            if (string.IsNullOrWhiteSpace(keyword)) {
                return BadRequest(new { message = "Vui lòng nhập từ khóa tìm kiếm!" });
            }

            var result = await _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.ProductName.Contains(keyword) ||
                            p.Barcode.Contains(keyword) ||
                            (p.Category != null && p.Category.CategoryName.Contains(keyword)))
                .Select(p => new ProductDto {
                    ProductId = p.ProductId,
                    Barcode = p.Barcode,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "Không xác định"
                })
                .OrderBy(p => p.ProductId)
                .ToListAsync();

            return Ok(result);
        }

        // 4. POST: Thêm mới sản phẩm
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product newProduct) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, newProduct);
        }

        // 5. PUT: Cập nhật thông tin sản phẩm
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updateProduct) {
            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần cập nhật!" });
            }

            product.Barcode = updateProduct.Barcode;
            product.ProductName = updateProduct.ProductName;
            product.Price = updateProduct.Price;
            product.StockQuantity = updateProduct.StockQuantity;
            product.CategoryId = updateProduct.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. DELETE: Xóa sản phẩm (Chỉ Admin)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa!" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Lấy chuỗi kết nối tập trung từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Đăng ký DbContext sử dụng SQL Server qua cơ chế Dependency Injection (DI Container)
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString)
           .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)));

// Cấu hình dịch vụ CORS cho phép ứng dụng Client (WinForms / Web) gọi API
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers();

// Cấu hình dịch vụ xác thực JWT Bearer
var jwtSecret = builder.Configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!";
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Cấu hình Swagger/OpenAPI tích hợp kiểm thử Bearer Token
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { 
        Title = "Hệ thống Bán lẻ Cô Ba Sài Gòn API", 
        Version = "v1",
        Description = "Nghiên cứu và Hiện thực hóa Hệ thống Quản lý Bán lẻ và Tồn kho theo Kiến trúc Client-Server (RESTful API & WinForms) — Áp dụng cho Hệ thống Bán lẻ Cô Ba Sài Gòn"
    });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme {
        Description = "Nhập 'Bearer [khoảng trắng] [chuỗi_token_của_bạn]' vào ô bên dưới.\r\n\r\nVí dụ: 'Bearer eyJhbGci...'",
        Name = "Authorization",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Type = Microsoft.OpenApi.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(_ => new Microsoft.OpenApi.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.OpenApiSecuritySchemeReference("Bearer", null, null),
            new List<string>()
        }
    });
});

var app = builder.Build();

// Tự động khởi tạo CSDL và cập nhật Migration (kèm dữ liệu mẫu) khi khởi động API
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SupermarketDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniSupermarket.API v1");
    try
    {
        var uiAsm = typeof(Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions).Assembly;
        var cssBuilder = new StringBuilder("<style>");
        foreach (var resName in new[] {
            "Swashbuckle.AspNetCore.SwaggerUI.node_modules.swagger_ui_dist.swagger-ui.css",
            "Swashbuckle.AspNetCore.SwaggerUI.node_modules.swagger_ui_dist.index.css"
        })
        {
            using var stream = uiAsm.GetManifestResourceStream(resName);
            if (stream != null)
            {
                using var gz = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress);
                using var reader = new System.IO.StreamReader(gz, Encoding.UTF8);
                cssBuilder.AppendLine(reader.ReadToEnd());
            }
        }
        cssBuilder.AppendLine("</style>");
        c.HeadContent = cssBuilder.ToString();
    }
    catch { }
});

app.UseHttpsRedirection();

// Kích hoạt CORS
app.UseCors("AllowAll");

// Bắt buộc gọi UseAuthentication trước UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

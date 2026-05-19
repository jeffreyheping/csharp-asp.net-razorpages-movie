// ============================================================
// Article 1: 开始使用 Razor Pages（原始模板）
// ============================================================
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddRazorPages();
// var app = builder.Build();
// app.UseHttpsRedirection();
// app.MapRazorPages().WithStaticAssets();
// app.Run();

// ============================================================
// Article 2: 添加模型 - 注册 DbContext 服务
// Article 4: 使用 SQLite 数据库 - 注册 SeedData 初始化器
// Article 8: 添加验证 - 注册 Microsoft.Extensions.Validation 服务
// ============================================================
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Article 2 & 4: 注册 SQLite 数据库上下文
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

// Article 4: 注册 SeedData 初始化服务（无需额外包）

// Article 8: 注册统一验证 API 服务（.NET 10 新增）
builder.Services.AddValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Article 4: 调用 SeedData.Initialize 填充种子数据
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.Run();

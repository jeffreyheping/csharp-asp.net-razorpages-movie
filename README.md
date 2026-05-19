# RazorPagesMovie - ASP.NET Core Razor Pages 教程项目

> 本项目是学习微软官方 ASP.NET Core Razor Pages 教程的完整实践成果。

## 项目背景

**教程来源：** [Microsoft Learn - Razor Pages 教程系列](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/razor-pages/)

**开发环境：**
- .NET 10.0
- VS Code
- SQLite 数据库
- Windows 11

## 项目简介

RazorPagesMovie 是一个简单的电影管理 Web 应用，实现了基本的 CRUD（创建、读取、更新、删除）功能。项目完整覆盖了微软官方 8 篇 Razor Pages 入门教程的全部内容，是学习 ASP.NET Core Web 开发的绝佳起点。

## 技术栈

| 技术 | 用途 |
|------|------|
| ASP.NET Core 10 | Web 框架 |
| Razor Pages | 视图引擎 |
| Entity Framework Core | ORM 框架 |
| SQLite | 数据库 |
| Bootstrap | 前端样式 |
| jQuery Validation | 客户端验证 |

## 教程完成进度

| 序号 | 教程标题 | 主要内容 | 状态 |
|------|----------|----------|------|
| 1 | 开始使用 Razor Pages | 创建项目、项目结构 | ✅ |
| 2 | 添加模型 | 创建 Movie 模型、DbContext 配置 | ✅ |
| 3 | 搭建"电影"模型的基架 | 生成 CRUD 页面 | ✅ |
| 4 | 使用 SQL 数据库 | SQLite 配置、数据迁移、种子数据 | ✅ |
| 5 | 更新生成的页面 | Display 特性、路由模板 | ✅ |
| 6 | 添加搜索 | 搜索功能、LINQ 查询 | ✅ |
| 7 | 添加新字段 | Rating 字段、数据库迁移 | ✅ |
| 8 | 添加验证 | DataAnnotations 验证特性 | ✅ |

## 项目结构

```
RazorPagesMovie/
├── Data/
│   └── RazorPagesMovieContext.cs    # EF Core 数据库上下文
├── Migrations/                       # 数据库迁移文件
│   ├── 20260506051613_InitialCreate.cs
│   └── 20260506052137_RatingAndValidation.cs
├── Models/
│   ├── Movie.cs                     # 电影模型（含验证特性）
│   └── SeedData.cs                  # 种子数据初始化
├── Pages/
│   ├── Movies/                      # CRUD 页面
│   │   ├── Index.cshtml             # 电影列表 + 搜索
│   │   ├── Create.cshtml            # 创建电影
│   │   ├── Edit.cshtml              # 编辑电影
│   │   ├── Details.cshtml           # 电影详情
│   │   └── Delete.cshtml            # 删除电影
│   ├── Shared/
│   │   └── _Layout.cshtml           # 布局页
│   └── ...
├── wwwroot/                         # 静态资源（Bootstrap、jQuery）
├── Program.cs                       # 应用程序入口
├── appsettings.json                 # 配置文件
└── RazorPagesMovie.csproj          # 项目文件
```

## 功能特性

### 核心功能
- ✅ 电影列表展示
- ✅ 创建新电影
- ✅ 编辑电影信息
- ✅ 查看电影详情
- ✅ 删除电影

### 高级功能
- ✅ 按标题搜索电影
- ✅ 按流派筛选电影
- ✅ 数据验证（客户端 + 服务端）
- ✅ 数据库自动迁移
- ✅ 种子数据初始化

## 数据模型

```csharp
public class Movie
{
    public int Id { get; set; }
    
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Title { get; set; }
    
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string Genre { get; set; }
    
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; }
}
```

## 快速开始

### 前置要求
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- VS Code 或 Visual Studio

### 运行步骤

```bash
# 1. 克隆仓库
git clone https://github.com/jeffreyheping/csharp-asp.net-razorpages-movie.git
cd csharp-asp.net-razorpages-movie/RazorPagesMovie

# 2. 还原依赖
dotnet restore

# 3. 运行数据库迁移（如需要）
dotnet ef database update

# 4. 启动应用
dotnet run
```

应用将在 `https://localhost:5001` 或 `http://localhost:5000` 启动。

### 访问电影管理页面
启动后访问：`https://localhost:5001/Movies`

## 学习笔记

### 本项目的特点

1. **完整注释保留**：每个文件的修改都保留了历史版本（注释形式），清晰展示了教程各阶段的代码变化。

2. **来源标注**：所有代码修改都标注了来源文章（如 `// Article 5: 更新生成的页面`），方便追溯。

3. **手动脚手架**：由于脚手架工具在 .NET 10 环境下出现兼容性问题，所有 CRUD 页面均为手动创建，更深入理解了 Razor Pages 的工作原理。

### 关键技术点

- **Razor Pages 路由**：使用 `@page "{id:int}"` 实现友好的 URL 路由
- **Entity Framework Core**：Code First 开发模式、迁移管理
- **模型验证**：DataAnnotations 特性实现声明式验证
- **LINQ 查询**：动态查询构建、IQueryable 延迟执行
- **Tag Helpers**：`asp-for`、`asp-page` 等简化 HTML 生成

## 参考资料

- [ASP.NET Core Razor Pages 官方教程](https://learn.microsoft.com/zh-cn/aspnet/core/tutorials/razor-pages/)
- [Entity Framework Core 文档](https://learn.microsoft.com/zh-cn/ef/core/)
- [ASP.NET Core 官方文档](https://learn.microsoft.com/zh-cn/aspnet/core/)

## 许可证

本项目仅用于学习目的，基于微软官方教程完成。

---

**开发时间：** 2026年5月6日  
**完成状态：** ✅ 全部 8 篇教程完成  
**最后更新：** 2026年5月19日

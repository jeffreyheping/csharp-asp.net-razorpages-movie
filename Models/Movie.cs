// ============================================================
// Article 2: 添加模型 - 创建 Movie 类（初始基架版本）
// ============================================================
// using System.ComponentModel.DataAnnotations;
//
// namespace RazorPagesMovie.Models;
// public class Movie
// {
//     public int Id { get; set; }
//     public string? Title { get; set; }
//     [DataType(DataType.Date)]
//     public DateTime ReleaseDate { get; set; }
//     public string? Genre { get; set; }
//     public decimal Price { get; set; }
// }

// ============================================================
// Article 5: 更新生成的页面 - 添加 [Display]、[DataType(Date)]、[Column] 特性
// ============================================================
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
//
// namespace RazorPagesMovie.Models;
//
// public class Movie
// {
//     public int Id { get; set; }
//     public string Title { get; set; } = string.Empty;
//
//     [Display(Name = "Release Date")]
//     [DataType(DataType.Date)]
//     public DateTime ReleaseDate { get; set; }
//     public string Genre { get; set; } = string.Empty;
//
//     [Column(TypeName = "decimal(18, 2)")]
//     public decimal Price { get; set; }
// }

// ============================================================
// Article 7: 添加新字段 - 添加 Rating 属性
// Article 8: 添加验证 - 添加 [Required]、[StringLength]、[RegularExpression]、[Range] 验证特性
// 最终版 Movie 类，完整包含所有8篇教程的修改
// ============================================================
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Movie
{
    // --- Article 2: 初始字段 ---
    public int Id { get; set; }

    // --- Article 8: 添加验证特性 ---
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Title { get; set; } = string.Empty;

    // --- Article 5: 添加 [Display] 和 [DataType(Date)] ---
    // --- Article 8: 添加 [Required] ---
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime ReleaseDate { get; set; }

    // --- Article 8: 添加验证特性 ---
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string Genre { get; set; } = string.Empty;

    // --- Article 5: 添加 [Column(TypeName)] ---
    // --- Article 8: 添加 [Range] 和 [DataType(Currency)] ---
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    // --- Article 7: 添加新字段 Rating ---
    // --- Article 8: 添加验证特性 ---
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; } = string.Empty;
}

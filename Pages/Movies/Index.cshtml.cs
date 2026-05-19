using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

// ============================================================
// Article 2: 搭建"电影"模型的基架 - 原始 Index 页面模型
// ============================================================
// public class IndexModel : PageModel
// {
//     private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
//     public IndexModel(...) { _context = context; }
//     public IList<Movie> Movie { get;set; } = default!;
//     public async Task OnGetAsync()
//     {
//         Movie = await _context.Movie.ToListAsync();
//     }
// }

// ============================================================
// Article 6: 添加搜索 - 添加 SearchString、Genres、MovieGenre 属性和搜索查询
// ============================================================
// Article 6: 添加搜索 - 添加流派查询（Genres SelectList）
// ============================================================
// Article 7: 添加新字段 - Index 已包含 Rating 列（仅修改视图）
// ============================================================
// Article 8: 添加验证 - 验证特性在模型层自动生效，页面无需修改
// ============================================================

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        // Article 6: 搜索框 - 按电影标题搜索
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        // Article 6: 流派下拉列表
        public SelectList? Genres { get; set; }

        // Article 6: 选中的流派
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Article 6: 构建流派查询，生成下拉列表
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            // Article 6: 查询电影（带搜索过滤）
            var movies = from m in _context.Movie
                         select m;

            // Article 6: 如果 SearchString 不为空，按标题过滤
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            // Article 6: 如果 MovieGenre 不为空，按流派过滤
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            // Article 6: 生成流派 SelectList（去重后按字母排序）
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }
    }
}

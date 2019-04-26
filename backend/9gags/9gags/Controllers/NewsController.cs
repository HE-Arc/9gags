using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using _9gags.Models;
using Microsoft.EntityFrameworkCore;

namespace _9gags.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        #region initalisation 
        private readonly GagsContext _context;
        public static IHostingEnvironment _environment;
        public NewsController(IHostingEnvironment environment, GagsContext context)
        {
            _environment = environment;
            _context = context;
        }
        #endregion

        #region get image news
        [HttpGet]
        public async Task<ActionResult<Article>> GeArticles()
        {
            long id = 1;
            var user = _context.Users
            .Include(e => e.Views)
            .ThenInclude(e => e.Article).Where(u => u.Id == id).First();

            var dbArticles = await _context.Articles.ToListAsync();
           Article resultArticle = null;
            try
            {
                var articleView = user.Views.Select(v => v.Article);
                resultArticle = dbArticles.Where(aDb => !articleView.Any(aView => aView.Id == aDb.Id))
                    .OrderByDescending(a => a.ReleaseDate).First();

            }
            catch(Exception e)
            {
                resultArticle = dbArticles.OrderByDescending(a => a.ReleaseDate).First();
            }
           
            user.Views.Add(new View { Article = resultArticle });
            await _context.SaveChangesAsync();
            return resultArticle;

        }

        [HttpGet]
        public async Task<ActionResult<Article>> GeArticles()
        {
            long id = 1;
            var user = _context.Users
            .Include(e => e.Views)
            .ThenInclude(e => e.Article).Where(u => u.Id == id).First();

            var dbArticles = await _context.Articles.ToListAsync();
            Article resultArticle = null;
            try
            {
                var articleView = user.Views.Select(v => v.Article);
                resultArticle = dbArticles.Where(aDb => !articleView.Any(aView => aView.Id == aDb.Id))
                    .OrderByDescending(a => a.ReleaseDate).First();

            }
            catch (Exception e)
            {
                resultArticle = dbArticles.OrderByDescending(a => a.ReleaseDate).First();
            }

            user.Views.Add(new View { Article = resultArticle });
            await _context.SaveChangesAsync();
            return resultArticle;

        }
        #endregion

    }
}
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

        public class ArticleVote
        {
            public Article Article { get; set; }
            public int vote { get; set; }
        }
            

        #endregion

        #region get image news
        [HttpGet]
        public async Task<ActionResult<ArticleVote>> GetArticles()
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
           
            try
            {
                user.Views.Add(new View { Article = resultArticle });
                await _context.SaveChangesAsync();
                int point;
                try
                {
                    var voteImage = _context.Articles
                   .Include(e => e.Votes).Where(a => a.Id == resultArticle.Id).First();

                    point = voteImage.Votes.Select(v => v.Point).Sum();
                }
                catch(Exception ex)
                {
                    point = 0;
                }

                resultArticle.Views.Clear();
                resultArticle.Votes.Clear();
                return new ArticleVote() {
                Article = resultArticle,
                vote = point
                };

            }
            catch (Exception e)
            {
                return new ArticleVote();
            }

            

        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<string>>> ResetArticles()
        {
            long id = 1;
            var user = _context.Users
            .Include(e => e.Views)
            .ThenInclude(e => e.Article).Where(u => u.Id == id).First();

            user.Views.Clear();
            await _context.SaveChangesAsync();

            return new string[] { "ok" };

        }
        #endregion

    }
}
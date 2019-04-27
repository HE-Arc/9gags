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
    public class DataController : ControllerBase
    {
        #region initalisation 
        private readonly GagsContext _context;
        public static IHostingEnvironment _environment;
        public DataController(IHostingEnvironment environment, GagsContext context)
        {
            _environment = environment;
            _context = context;
        }

         

        #endregion

        #region get image news
        [HttpGet("{mode}")]
        public async Task<ActionResult<Article>> GetArticles(long mode)
        {
            long id = 1;
            var user = _context.Users
            .Include(e => e.Views)
            .ThenInclude(e => e.Article).Where(u => u.Id == id).First();
            var dbArticles = await _context.Articles.Include(a => a.Comments)
                .ThenInclude(c => c.User)
                .ToListAsync();
           Article resultArticle = null;
            try
            {
                var articleView = user.Views.Select(v => v.Article);
                if(mode == 1)
                {
                    resultArticle = dbArticles.Where(aDb => !articleView.Any(aView => aView.Id == aDb.Id))
                    .OrderByDescending(a => a.ReleaseDate).First();
                }
                else if(mode == 2)
                {
                    resultArticle = dbArticles.Where(aDb => !articleView.Any(aView => aView.Id == aDb.Id))
                    .OrderByDescending(a => a.ReleaseDate).OrderByDescending(a => a.points).First();
                }
                else
                {
                    return new Article();
                }


            }
            catch(Exception e)
            {
                return new Article();
            }
           
            try
            {
                user.Views.Add(new View { Article = resultArticle });
                await _context.SaveChangesAsync();
                int point;
                try
                {
                    point = resultArticle.points;
                }
                catch(Exception ex)
                {
                    point = 0;
                }

                resultArticle.Views.Clear();
                resultArticle.Votes.Clear();
                return resultArticle;

            }
            catch (Exception e)
            {
                return new Article();
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
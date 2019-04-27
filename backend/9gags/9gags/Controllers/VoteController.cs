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
    public class VoteController : ControllerBase
    {
        #region initalisation 
        private static readonly string directory = "/uploads/";
        private readonly GagsContext _context;
        public static IHostingEnvironment _environment;
        public VoteController(IHostingEnvironment environment, GagsContext context)
        {
            _environment = environment;
            _context = context;
        }
        #endregion
        #region points
        // PUT: api/image/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutPoint(long id, int point)
        {
            Article article = _context.Articles.Find(id);
            int[] pointsOK = new int[] { 1, 0, -1 };
            if (article == null || id != article.Id || !pointsOK.Contains(point))
            {
                return "err";
            }

            long iduser = 1;
            var user = _context.Users
            .Include(e => e.Votes)
            .ThenInclude(e => e.Article).Where(u => u.Id == iduser).First();
            //var voteArticle = user.Votes.Where(v => v.ArticleId == article.Id);
            var voteArticle = user.Votes.Where(v => v.Article.Id == article.Id);

            try
            {
                if (voteArticle.Any())
                {
                    var currentPoint = voteArticle.First().Point;
                    if (currentPoint != point)
                    {
                        article.points += point;
                    }
                    voteArticle.First().Point = point;
                }
                else
                {
                    user.Votes.Add(new Vote
                    {
                        Article = article,
                        Point = point,
                    });

                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            await _context.SaveChangesAsync();
            return "ok";
        }
        #endregion
 

    }
}
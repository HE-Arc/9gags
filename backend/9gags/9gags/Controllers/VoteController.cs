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
        //Post : /api/point
        [HttpPost]
        public async Task<ActionResult<string>> PostPoint(long id, int point)
        {
            Article article = _context.Articles.Find(id);
            if (article == null || id != article.Id)
            {
                return "err";
            }

            long iduser = 1;
            var user = _context.Users
            .Include(e => e.Comments)
            .Where(u => u.Id == iduser).First();

            var votes = _context.Users.Include(e => e.Votes).ThenInclude(e => e.Article).Where(u => u.Id == iduser).First().Votes.Where(u=>u.Article.Id == article.Id);
            int realPoint = getVerifiedPoint(point);
            int oldPoint = 0;

            try
            {
                if (!votes.Any())
                {
                    user.Votes.Add(new Vote
                    {
                        Article = article,
                        User = user,
                        Point = realPoint
                    });
                }
                else
                {
                    oldPoint = votes.First().Point;
                    votes.First().Point = realPoint;
                }
                article.points -= oldPoint;
                article.points += realPoint;
                await _context.SaveChangesAsync();
                return "ok";

            }
            catch (Exception e)
            {
                return e.ToString();
            }            
        }
        #endregion
 
        private int getVerifiedPoint(int point)
        {
            return point > 0 ? 1 : (point < 0 ? -1 : 0); //If value greather or equal to 1 set to 1, if value smaller or equal to -1 set to -1 else 0! Ensure the value is between -1 and 1
        }
    }
}
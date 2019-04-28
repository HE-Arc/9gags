using _9gags.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _9gags.Helper
{
    public class UserHelper
{
    public static long GetUserIdFromToken(GagsContext context, ClaimsPrincipal user)
        {
            var auth0 = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            User userDb;
            try
            {
                 userDb = context.Users.Where(u => u.Auth0.Equals(auth0)).First();
            }
            catch(Exception e)
            {
                 userDb = new User();
            }
 
            return userDb.Id;
        }

        public static int ArticleUserPoint(GagsContext context, long userId, long articleId)
        {
        
            try
            {
                var user = context.Users.Where(u => u.Id == userId).First();
                return user.Votes.Where(v => v.Article.Id == articleId).First().Point;
            }
            catch(Exception e)
            {
                return 0;
            }
            
            
        }
}
}

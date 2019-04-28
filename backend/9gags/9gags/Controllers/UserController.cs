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
using Microsoft.AspNetCore.Authorization;
using _9gags.Helper;
using System.Security.Claims;

namespace _9gags.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        #region initalisation 

        private readonly GagsContext _context;
        public static IHostingEnvironment _environment;
        public UserController(IHostingEnvironment environment, GagsContext context)
        {
            _environment = environment;
            _context = context;
        }
        #endregion
        #region Create user
        // PUT: api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(string username)
        {
            var auth0 = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            User userDb;
            try
            {
                userDb = _context.Users.Where(u => u.Auth0.Equals(auth0)).First();
            }
            catch (Exception e)
            {
                userDb = null;
            }
            if (userDb == null)
            {
                userDb = _context.Add(new User {
                    Auth0 = auth0,
                    Username = username})
                    .Entity;
            }
            await _context.SaveChangesAsync();
            return userDb;
        }
        #endregion

    }
}
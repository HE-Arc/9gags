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
        public async Task<ActionResult<IEnumerable<Article>>> GeArticles()
        {
            
            return await _context.Articles.OrderByDescending(s => s.ReleaseDate).ToListAsync();
        }
        #endregion

    }
}
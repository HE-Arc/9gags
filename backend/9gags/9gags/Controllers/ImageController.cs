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
    public class ImageController : ControllerBase
    {
        #region initalisation 
        private static readonly string directory = "/uploads/";
        private readonly GagsContext _context;
        public static IHostingEnvironment _environment;
        public ImageController(IHostingEnvironment environment, GagsContext context)
        {
            _environment = environment;
            _context = context;
        }

        public class FileUploadAPI
        {
            public IFormFile file { get; set; }
        }
        #endregion
        #region Post image
        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> Post(FileUploadAPI file, string title)
        {
            if(file.file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + directory))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + directory);
                    }
                    var filename = GenerateImageName(file.file.FileName);
                    using (FileStream fileStream = new FileStream(Path.Combine(_environment.WebRootPath + directory,filename), FileMode.Create))
                    {

                        await file.file.CopyToAsync(fileStream);
                        
                    }
                   var res = await GenerateinDB(directory + filename,title);
                   return new string[] { res };

                }
                catch(Exception e)
                {
                    return new string[] { e.ToString() };
                }
            }
            else
            {
                return new string[] { "error load image" };
      
            }
        }
        #endregion
        #region get image news
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GeArticles()
        {
            return await _context.Articles.ToListAsync();
        }
        // PUT: api/image/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetImage(long id)
        {
            Article article = _context.Articles.Include(e => e.Comments).Where(a => a.Id == id).First();
            return article;
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
            var voteArticle = user.Votes.Where(v => v.ArticleId == article.Id);

            try
            {
                if (voteArticle.Any())
                {
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
            }catch(Exception e)
            {
                return e.ToString();
            }
            await _context.SaveChangesAsync();
            return "ok";
        }
        #endregion
        #region private methods

        private string GenerateImageName(string filename)
        {
            var imageId = Guid.NewGuid();
            var extension = Path.GetExtension(filename);
            return $"{imageId.ToString()}{extension}";

        }
       private async Task<string> GenerateinDB(string path, string title)
        {
            Article article = new Article {
                Title = title,
                Path = path,
                ReleaseDate = DateTime.Now
        };
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return "ok";
        }
        #endregion

    }
}
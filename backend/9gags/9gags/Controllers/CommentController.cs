﻿using System;
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
    public class CommentController : ControllerBase
    {
        #region initalisation 

        private readonly GagsContext _context;
        public static IHostingEnvironment _environment;
        public CommentController(IHostingEnvironment environment, GagsContext context)
        {
            _environment = environment;
            _context = context;
        }
        #endregion
        #region comment
        // PUT: api/comment/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutPoint(long id, string comment)
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

            try
            {
                user.Comments.Add(new Comment
                {
                    Article = article,
                    Comments = comment,
                    ReleaseDate = DateTime.Now
                });
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _9gags.Models
{
    public class User
    {
        public long Id { get; set; }
        public string auth0 { get; set; }
        public string username { get; set; }


        public List<Vote> Votes { get; set; } = new List<Vote>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<View> Views { get; set; } = new List<View>();
    }
}

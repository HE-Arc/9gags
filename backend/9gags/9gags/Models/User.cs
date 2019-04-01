using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9gags.Models
{
    public class User
    {
        public long Id { get; set; }
        public string email { get; set; }
        public string username { get; set; }

        public List<Vote> Votes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<View> Views { get; set; }
    }
}

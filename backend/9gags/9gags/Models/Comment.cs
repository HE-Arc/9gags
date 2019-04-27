using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9gags.Models
{
    public class Comment
{
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public Article Article { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public string Comments { get; set; }
    }
}

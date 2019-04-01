using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _9gags.Models
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public int points { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public List<Vote> Votes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<View> Views { get; set; }

    }
}


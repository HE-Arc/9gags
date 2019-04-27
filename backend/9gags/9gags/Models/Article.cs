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

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public List<Vote> Votes { get; set; } = new List<Vote>();
        public List<Comment> Comments { get; set; } =  new List<Comment>();
        public List<View> Views { get; set; } = new List<View>();


    }
}


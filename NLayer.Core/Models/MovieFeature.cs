using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class MovieFeature
    {
        public int Id { get; set; }
        public string? Overview { get; set; }
        public int Year { get; set; }
        public int ImdbRating { get; set; }
        public int MoviesId { get; set; }
        public Movies? Movie { get; set; }
    }
}

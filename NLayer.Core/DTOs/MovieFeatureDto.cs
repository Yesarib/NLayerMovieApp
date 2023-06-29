using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class MovieFeatureDto
    {
        public int Id { get; set; }
        public string? Overview { get; set; }
        public int Year { get; set; }
        public int ImdbRating { get; set; }
        public int MoviesId { get; set; }
    }
}

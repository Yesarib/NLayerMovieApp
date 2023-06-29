using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Movies : BaseEntity
    {
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category>? Category { get; set; }
        public MovieFeature? MovieFeature { get; set; }



    }
}

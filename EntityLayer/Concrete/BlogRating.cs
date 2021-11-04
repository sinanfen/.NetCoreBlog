using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRating
    {
        public int BlogRatingID { get; set; }
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRatingCount { get; set; }
    }
}

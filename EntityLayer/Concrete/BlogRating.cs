using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class BlogRating
    {
        [Key]
        public int BlogRatingId { get; set; }
        public int BlogId { get; set; }
        public int BlogRatingScore { get; set; }
        public int BlogTotalScore { get; set; }
        
    }
}

using ReviewsAPI.Models;

namespace ReviewsAPI.Dto
{
    public class DrinkReviewDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<ReviewDto>? Review { get; set; }
    }
}

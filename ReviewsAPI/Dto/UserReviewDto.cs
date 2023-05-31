using ReviewsAPI.Models;

namespace ReviewsAPI.Dto
{
    public class ReviewerReviewDto
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<ReviewDto>? Review { get; set; }
    }
}

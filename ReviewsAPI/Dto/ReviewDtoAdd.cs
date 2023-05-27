using ReviewsAPI.Models;

namespace ReviewsAPI.Dto
{
    public class ReviewDtoAdd
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public float Rating { get; set; }
    }
}

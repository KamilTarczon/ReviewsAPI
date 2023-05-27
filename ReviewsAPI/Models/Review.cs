namespace ReviewsAPI.Models
{
    public class Review
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public float Rating { get; set; }
        public Reviewer? Reviewer { get; set; }
        public Drink? Drink { get; set; }
        public int? DrinkId { get; set; }
        public int? ReviewerId { get; set; }

        public Review(string title, string text, float rating)
        {
            Title = title;
            Text = text;
            Rating = rating;
        }

    }
}

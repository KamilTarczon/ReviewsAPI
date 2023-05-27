namespace ReviewsAPI.Models
{
    public class Drink
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Review>? Review { get; set; }

        public Drink(string name)
        { 
            Name = name;
        }
    }
}

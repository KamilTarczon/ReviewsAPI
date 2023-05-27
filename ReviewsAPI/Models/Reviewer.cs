namespace ReviewsAPI.Models
{
    public class Reviewer
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Review>? Review { get; set; }

        public Reviewer(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}

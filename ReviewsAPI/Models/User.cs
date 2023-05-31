namespace ReviewsAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Review>? Review { get; set; }
        public User(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Models;

namespace ReviewsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Drink> Drinks { get; set; }  // Utworzenie DbSet<Model>, nazwa tablicy (z reguły w liczbie mnogiej)
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Review>  Reviews { get; set; }
    }
}
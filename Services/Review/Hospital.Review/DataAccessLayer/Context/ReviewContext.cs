using Hospital.Review.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Review.DataAccessLayer.Context
{
    public class ReviewContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial catalog=ReviewDb;User=sa;Password=123456aA*;Trust Server Certificate=true");
        }
        public DbSet<UserReview> UserReviews { get; set; }
    }
}

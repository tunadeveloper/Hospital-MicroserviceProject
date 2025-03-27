namespace Hospital.Review.DataAccessLayer.Entities
{
    public class UserReview
    {
        public int UserReviewId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ReviewDetail { get; set; }
    }
}

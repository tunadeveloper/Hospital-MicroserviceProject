namespace Hospital.Review.CQRS.Results
{
    public class GetReviewQueryResult
    {
        public int UserReviewId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ReviewDetail { get; set; }
    }
}

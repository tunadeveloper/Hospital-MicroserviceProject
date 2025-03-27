namespace Hospital.Review.CQRS.Commands
{
    public class CreateReviewCommand
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ReviewDetail { get; set; }
    }
}

namespace Hospital.Review.CQRS.Commands
{
    public class RemoveReviewCommand
    {
        public int Id { get; set; }

        public RemoveReviewCommand(int id)
        {
            Id = id;
        }
    }
}

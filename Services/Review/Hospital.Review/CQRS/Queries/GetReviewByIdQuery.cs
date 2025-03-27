namespace Hospital.Review.CQRS.Queries
{
    public class GetReviewByIdQuery
    {
        public int Id { get; set; }

        public GetReviewByIdQuery(int id)
        {
            Id = id;
        }
    }
}

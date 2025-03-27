using Hospital.Review.CQRS.Commands;
using Hospital.Review.DataAccessLayer.Context;

namespace Hospital.Review.CQRS.Handlers
{
    public class RemoveReviewCommandHandler
    {
        private readonly ReviewContext _reviewContext;

        public RemoveReviewCommandHandler(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public async Task Handle(RemoveReviewCommand command)
        {
            var value = await _reviewContext.UserReviews.FindAsync(command.Id);
            _reviewContext.UserReviews.Remove(value);
            await _reviewContext.SaveChangesAsync();
        }
    }
}

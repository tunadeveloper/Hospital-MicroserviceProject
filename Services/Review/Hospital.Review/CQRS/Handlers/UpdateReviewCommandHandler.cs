using Hospital.Review.CQRS.Commands;
using Hospital.Review.DataAccessLayer.Context;

namespace Hospital.Review.CQRS.Handlers
{
    public class UpdateReviewCommandHandler
    {
        private readonly ReviewContext _reviewContext;

        public UpdateReviewCommandHandler(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public async Task Handle(UpdateReviewCommand command)
        {
            var value = await _reviewContext.UserReviews.FindAsync(command.UserReviewId);
            value.ReviewDetail = command.ReviewDetail;
            value.Date = command.Date;
            value.Name = command.Name;
            value.UserId = command.UserId;
            await _reviewContext.SaveChangesAsync();
        }
    }
}

using Hospital.Review.CQRS.Commands;
using Hospital.Review.DataAccessLayer.Context;
using Hospital.Review.DataAccessLayer.Entities;

namespace Hospital.Review.CQRS.Handlers
{
    public class CreateReviewCommandHandler
    {
        private readonly ReviewContext _reviewContext;

        public CreateReviewCommandHandler(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public async Task Handle(CreateReviewCommand command)
        {
            _reviewContext.UserReviews.Add(new UserReview
            {
                Date = command.Date,
                Name = command.Name,
                ReviewDetail = command.ReviewDetail,
                UserId = command.UserId
            });
            await _reviewContext.SaveChangesAsync();
        }
    }
}

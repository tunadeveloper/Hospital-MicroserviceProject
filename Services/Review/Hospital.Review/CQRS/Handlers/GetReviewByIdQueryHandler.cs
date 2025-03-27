using Hospital.Review.CQRS.Queries;
using Hospital.Review.CQRS.Results;
using Hospital.Review.DataAccessLayer.Context;

namespace Hospital.Review.CQRS.Handlers
{
    public class GetReviewByIdQueryHandler
    {
        private readonly ReviewContext _reviewContext;

        public GetReviewByIdQueryHandler(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public async Task<GetReviewByIdQueryResult> Handle(GetReviewByIdQuery query)
        {
            var value = await _reviewContext.UserReviews.FindAsync(query.Id);
            return new GetReviewByIdQueryResult
            {
                UserReviewId = value.UserReviewId,
                Date = value.Date,
                Name = value.Name,
                ReviewDetail = value.ReviewDetail,
                UserId = value.UserId
            };
        }
        }
}

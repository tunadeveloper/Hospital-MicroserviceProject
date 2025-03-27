using Hospital.Review.CQRS.Results;
using Hospital.Review.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Review.CQRS.Handlers
{
    public class GetReviewQueryHandler
    {
        private readonly ReviewContext _reviewContext;

        public GetReviewQueryHandler(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public async Task<List<GetReviewQueryResult>> Handle()
        {
            var values = await _reviewContext.UserReviews.ToListAsync();
            return values.Select(value => new GetReviewQueryResult
            {
                UserReviewId = value.UserReviewId,
                Date = value.Date,
                Name = value.Name,
                ReviewDetail = value.ReviewDetail,
                UserId = value.UserId
            }).ToList();
        }
    }
}

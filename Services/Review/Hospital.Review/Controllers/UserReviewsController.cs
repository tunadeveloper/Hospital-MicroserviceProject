using Hospital.Review.CQRS.Commands;
using Hospital.Review.CQRS.Handlers;
using Hospital.Review.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Hospital.Review.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewsController : ControllerBase
    {
        private readonly CreateReviewCommandHandler _createReviewCommandHandler;
        private readonly GetReviewQueryHandler _getReviewQueryHandler;
        private readonly RemoveReviewCommandHandler _removeReviewCommandHandler;
        private readonly UpdateReviewCommandHandler _updateReviewCommandHandler;
        private readonly GetReviewByIdQueryHandler _getReviewByIdQueryHandler;

        public UserReviewsController(CreateReviewCommandHandler createReviewCommandHandler, GetReviewQueryHandler getReviewQueryHandler, RemoveReviewCommandHandler removeReviewCommandHandler, UpdateReviewCommandHandler updateReviewCommandHandler, GetReviewByIdQueryHandler getReviewByIdQueryHandler)
        {
            _createReviewCommandHandler = createReviewCommandHandler;
            _getReviewQueryHandler = getReviewQueryHandler;
            _removeReviewCommandHandler = removeReviewCommandHandler;
            _updateReviewCommandHandler = updateReviewCommandHandler;
            _getReviewByIdQueryHandler = getReviewByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ReviewList()
        {
            var value = await _getReviewQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            await _createReviewCommandHandler.Handle(command);
            return Ok("Ekleme Başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _updateReviewCommandHandler.Handle(command);
            return Ok("Güncelleme Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveReview(int id)
        {
            await _removeReviewCommandHandler.Handle(new RemoveReviewCommand(id));
            return Ok("Silme Başarılı!");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetReview(int id)
        {
            var value = await _getReviewByIdQueryHandler.Handle(new GetReviewByIdQuery(id));
            return Ok(value);
        }
    }
}

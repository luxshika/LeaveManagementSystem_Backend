using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(Review reviewRequest)
        {
            var res = await _reviewService.CreateReview(reviewRequest);
            return Ok(res);
        }


        [HttpGet]
        public async Task<ActionResult> GetReviews()
        {
            var res = await _reviewService.GetReviews();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReviewByID(int id)
        {
            var res = await _reviewService.GetReviewByID(id);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateReview(Review reviewRequest)
        {
            var res = await _reviewService.UpdateReview(reviewRequest);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var res = await _reviewService.DeleteReview(id);
            return Ok(res);

        }


    }
}

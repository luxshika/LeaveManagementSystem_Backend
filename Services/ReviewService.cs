using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Review> CreateReview(Review review)
        {
            return await _reviewRepository.CreateReview(review);
        }

        public async Task<string> DeleteReview(int id)
        {

            // is id exist 

            var res = await _reviewRepository.DeleteReview(id);
            return res;
        }

        public async Task<Review?> GetReviewByID(int id)
        {
            var res = await _reviewRepository.GetReviewByID(id);
            return res;
        }

        public async Task<List<Review>> GetReviews()
        {
            var res = await _reviewRepository.GetReviews();
            return res;
        }



        public async Task<Review> UpdateReview(Review reviewRequest)
        {
            var res = await _reviewRepository.UpdateReview(reviewRequest);
            return res;
        }
    }
}

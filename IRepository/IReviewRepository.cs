using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface IReviewRepository
    {
        Task<Review> CreateReview(Review review);
        Task<List<Review>> GetReviews();
        Task<Review?> GetReviewByID(int id);
        Task<Review> UpdateReview(Review reviewRequest);
        Task<string> DeleteReview(int id);
    }
}

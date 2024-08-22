using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IServices
{
    public interface IReviewService
    {
        Task<Review> CreateReview(Review review);
        Task<List<Review>> GetReviews();
        Task<Review?> GetReviewByID(int id);
        Task<Review> UpdateReview(Review review);
        Task<string> DeleteReview(int id);
    }
}

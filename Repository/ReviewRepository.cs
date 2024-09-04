using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly LMSDbContext _reviewcontext;
        public ReviewRepository(LMSDbContext reviewcontext)
        {
            _reviewcontext = reviewcontext;
        }

        public async Task<Review> CreateReview(Review review)
        {
            try
            {
                var res = _reviewcontext.Reviews.Add(review);
                await _reviewcontext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> DeleteReview(int id)
        {
            var review = await _reviewcontext.Reviews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (review == null)
            {
                return "Requested ID not available ";
            }
            _reviewcontext.Reviews.Remove(review);
            await _reviewcontext.SaveChangesAsync();
            return " suceeded";
        }

        public Task<Review?> GetReviewByID(int id)
        {
            try
            {
                var res = _reviewcontext.Reviews.Where(x => x.Id == id).FirstOrDefault();

                return Task.FromResult(res);


            }
            catch (Exception)
            {

                throw;
            }

        }
        public Task<List<Review>> GetReviews()
        {
            try
            {
                var res = _reviewcontext.Reviews.ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Review> UpdateReview(Review reviewRequest)
        {
            try
            {
                var res = _reviewcontext.Reviews.Update(reviewRequest);
                await _reviewcontext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

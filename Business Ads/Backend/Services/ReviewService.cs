using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class ReviewService : IServiceReview
    {
        private static readonly ReviewService instance = new ReviewService();
        private ReviewRepository repo;

        private ReviewService()
        {
            repo = new ReviewRepository();
        }

        public static ReviewService Instance
        {
            get { return instance; }
        }

        public List<ReviewClass> getAllReviews()
        {
            return repo.GetReviewList();
        }

        public void addReview(string review)
        {
            string user = "Dan Oliver";
            ReviewClass addingRev = new ReviewClass(user, review);
            repo.addReview(addingRev);
        }
    }

    interface IServiceReview
    {
        List<ReviewClass> getAllReviews();
        void addReview(string review);
    }
}

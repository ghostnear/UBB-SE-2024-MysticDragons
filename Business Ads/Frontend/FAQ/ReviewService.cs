using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class ReviewService : IServiceReview
    {
        private static readonly ReviewService instance = new ReviewService();
        private ReviewRepo repo;

        private ReviewService()
        {
            repo = new ReviewRepo();
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
            string user = "dummy"; 
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class ReviewService : IServiceReview
    {

        ReviewRepo repo;
        public ReviewService()
        {
            this.repo = new ReviewRepo();
        }

        public List<ReviewClass> getAllReviews()
        {
            return repo.GetReviewList();
        }

        public void addReview(String review)
        {
            String user = "dummy";
            ReviewClass addingRev = new ReviewClass(user, review);
            repo.addReview(addingRev);
        }
    }


        
    interface IServiceReview
    {
      public List<ReviewClass> getAllReviews();
        public void addReview(String review);

    }
}


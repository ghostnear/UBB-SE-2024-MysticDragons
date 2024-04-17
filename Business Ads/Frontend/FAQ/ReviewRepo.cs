using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class ReviewRepo : IReview
    {
            List<ReviewClass> reviewList;
            public ReviewRepo()
            {
                reviewList = new List<ReviewClass>();
                createReview();
            }
            public List<ReviewClass> GetReviewList()
            {
                return reviewList;
            }
            public void createReview()
            {
                ReviewClass r1 = new ReviewClass("ana", "shucks");
                ReviewClass r2 = new ReviewClass("dana", "good");
                ReviewClass r3 = new ReviewClass("aaa", "meh");
                ReviewClass r4 = new ReviewClass("lori", "da");
                ReviewClass r5 = new ReviewClass("sili", "nu");
                ReviewClass r6 = new ReviewClass("ili", "hhiiihi");

                reviewList.Add(r1);
                reviewList.Add(r2);
                reviewList.Add(r3);
                reviewList.Add(r4);
                reviewList.Add(r5);
                reviewList.Add(r6);


            }

            public void addReview(ReviewClass newR)
            {
                reviewList.Add(newR);
            }

            public void deleteReview(ReviewClass q)
            {
                reviewList.Remove(q);
            }


    }
        interface IReview
        {
            public List<ReviewClass> GetReviewList();
            public void createReview();
            public void addReview(ReviewClass newR);
            public void deleteReview(ReviewClass q);

        }
    }



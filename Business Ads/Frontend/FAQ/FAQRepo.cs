using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    class FAQRepository : IFAQ
    {
        List<FAQ> faqList;
        public FAQRepository() 
        {
            faqList = new List<FAQ>();
            createFAQ();
        }
        public List<FAQ> GetFAQList()
        {
            return faqList;
        }
        public void createFAQ()
        {
            FAQ q1 = new FAQ(1, "a", "e", "to");
            FAQ q2 = new FAQ(2, "b", "f", "o");
            FAQ q3 = new FAQ(3, "c", "g", "tog");
            FAQ q4 = new FAQ(4, "d", "h", "toa");

            faqList.Add(q1);
            faqList.Add(q2);
            faqList.Add(q3);
            faqList.Add(q4);
            faqList.Add(q1);
            faqList.Add(q2);
            faqList.Add(q3);
            faqList.Add(q4);
            faqList.Add(q1);
            faqList.Add(q2);
            faqList.Add(q3);
            faqList.Add(q4);
        }

        public void addFAQ(FAQ newQ)
        {
            faqList.Add(newQ);
        }

        public void deleteFAQ(FAQ q)
        {
            faqList.Remove(q);
        }


    }
    interface IFAQ
    {
        public List <FAQ> GetFAQList();
        public void createFAQ();
        public void addFAQ(FAQ newQ);
        public void deleteFAQ(FAQ q);

    }
}

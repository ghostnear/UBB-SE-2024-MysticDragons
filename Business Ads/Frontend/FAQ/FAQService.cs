using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class FAQService
    {
        FAQRepository repo;
        List<FAQ> submittedQuestions;
        public FAQService()
        {
            this.repo = new FAQRepository();
            submittedQuestions = new List<FAQ>();
        }

        public List<FAQ> getAll() 
        { 
            return repo.GetFAQList();
        }
        public void addSubmittedQuestion(FAQ newQ)
        {
            submittedQuestions.Add(newQ);
        }


    }
    interface IService
    {
        public List<FAQ> getAll();
        public void addSubmittedQuestion(FAQ newQ);

    }
}

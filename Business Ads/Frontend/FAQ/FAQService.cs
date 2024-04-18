using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class FAQService 
    {
        private static readonly FAQService instance = new FAQService();
        private FAQRepository repo;
        private List<FAQ> submittedQuestions;

        private FAQService()
        {
            repo = new FAQRepository();
            submittedQuestions = new List<FAQ>();
        }

        public static FAQService Instance
        {
            get { return instance; }
        }

        public List<FAQ> getAll()
        {
            return repo.GetFAQList();
        }

        public void addSubmittedQuestion(FAQ newQ)
        {
            submittedQuestions.Add(newQ);
        }

        public List<FAQ> getSubmittedQuestions()
        {
            return submittedQuestions;
        }
    }

}

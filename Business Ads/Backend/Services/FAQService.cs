using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class FAQService
    {
        private static readonly FAQService instance = new();
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

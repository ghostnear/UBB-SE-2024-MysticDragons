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
        public FAQService()
        {
            this.repo = new FAQRepository();
        }

        public List<FAQ> getAll() 
        { 
            return repo.GetFAQList();
        }
    

    }
    interface IService
    {
        public List<FAQ> getAll();

    }
}

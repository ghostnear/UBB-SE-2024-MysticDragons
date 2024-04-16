using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class TODOServices
    {
        TODORepository repository;
        public TODOServices()
        {
            this.repository = new TODORepository();
        }
        public List<TODOClass> getTODOS()
        {
            return repository.getTODOS();
        }
        public void addTODO(TODOClass obj)
        {
            repository.addingTODO(obj);
        }
        public void removeTODO(int id)
        {
            TODOClass todoToRemove = getTODOS().FirstOrDefault(todo => todo.ID == id);

            if (todoToRemove != null)
            {
                repository.removingTODO(todoToRemove);
            }
        }



    }

    interface IServicesTODO
    {
        public List<TODOClass> getTODOS();
        public void addTODO(TODOClass obj);
        public void removeTODO(int id);
    }
}

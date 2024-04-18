using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class TODOServices : IServicesTODO
    {
        private static readonly TODOServices instance = new TODOServices();
        private TODORepository repository;

        private TODOServices()
        {
            repository = new TODORepository();
        }

        public static TODOServices Instance
        {
            get { return instance; }
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
        List<TODOClass> getTODOS();
        void addTODO(TODOClass obj);
        void removeTODO(int id);
    }
}

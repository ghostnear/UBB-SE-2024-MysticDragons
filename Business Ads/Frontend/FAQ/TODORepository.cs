using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class TODORepository : IRepository
    {
        private List<TODOClass> todos;
        public TODORepository() 
        { todos = new List<TODOClass>(); createTODOS(); }
        public void addingTODO(TODOClass newTODO)
        {
            todos.Add(newTODO);
        }
        public void removingTODO(TODOClass newTODO)
        {
            todos.Remove(newTODO);
        }

        public List<TODOClass> getTODOS()
        {
            return todos;
        }

        public void createTODOS()
        {
            TODOClass t1 = new TODOClass("task 1");
            TODOClass t2 = new TODOClass("task 2");
            TODOClass t3 = new TODOClass("task 3");
            TODOClass t4 = new TODOClass("task 4");
            TODOClass t5 = new TODOClass("task 5");
            TODOClass t6 = new TODOClass("task 6");

            addingTODO(t1);
            addingTODO(t2);
            addingTODO(t3);
            addingTODO(t4);
            addingTODO(t5);
            addingTODO(t6);

        }


    }

    interface IRepository
    {
        public void addingTODO(TODOClass newTODO);
        public void removingTODO(TODOClass newTODO);
        public List<TODOClass> getTODOS();

        public void createTODOS();
    }
}

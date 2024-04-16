using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class TODOClass
    {
        private string _task;
        private int _id;

        public TODOClass(String task, int id)
        {
            this._task = task; this._id = id;
        }

        public string Task { get { return _task; } set { _task = value; } }

        public int ID { get { return _id; } set { _id = value; } }
        public override string ToString()
        {
            return $"{_id}. {_task}";
        }
    }
}

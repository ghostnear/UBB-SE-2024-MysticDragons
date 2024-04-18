using System;

namespace Frontend.FAQ
{
    internal class TODOClass
    {
        private string _task;
        private static int _lastID = 0;
        private int _id;

        public TODOClass(string task)
        {
            this._task = task;
            this._id = ++_lastID;
        }

        public string Task { get { return _task; } set { _task = value; } }

        public int ID { get { return _id; } }

        public override string ToString()
        {
            return $"{_id}. {_task}";
        }
    }
}

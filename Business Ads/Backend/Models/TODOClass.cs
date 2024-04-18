namespace Backend.Models
{
    public class TODOClass
    {
        // TODO: remove class from the name of the class lol.

        private string _task;
        private int _id;

        public TODOClass(string task)
        {
            _task = task;
        }
        
        public TODOClass() { }

        public string Task { get { return _task; } set { _task = value; } }

        public int ID { get { return _id; } set{ _id = value; } }

        public override string ToString()
        {
            return $"{_id}. {_task}";
        }
    }
}

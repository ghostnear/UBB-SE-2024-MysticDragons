namespace Backend.Models
{
    public class FAQ
    {
        private int _id;
        private static int _lastID = 0;
        private string _question;
        private string _answer;
        private string _topic;

        public FAQ()
        {

        }

        public FAQ(string q, string a, string topic)
        {
            _id = ++_lastID;
            _question = q;
            _answer = a;
            _topic = topic;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }

        public override string ToString()
        {
            return $"{_question}";
        }
    }

}

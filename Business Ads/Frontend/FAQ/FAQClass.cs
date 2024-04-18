using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
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
            this._id = ++_lastID;
            this._question = q;
            this._answer = a;
            this._topic = topic;
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

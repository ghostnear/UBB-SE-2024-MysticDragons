using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.FAQ
{
    internal class ReviewClass
    {
        private string _user;
        private string _review;

        public ReviewClass(string user, string review)
        {
            this._user = user;
            this._review = review;
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Review
        {
            get { return _review; }
            set { _review = value; }
        }

        public override string ToString()
        {
            return $"{this._review}";
        }
    }
}

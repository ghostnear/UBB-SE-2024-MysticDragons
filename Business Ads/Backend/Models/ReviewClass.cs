namespace Backend.Models
{
    public class ReviewClass
    {
        private string _user;
        private string _review;

        public ReviewClass(string user, string review)
        {
            this._user = user;
            this._review = review;
        }

        public ReviewClass() { }    

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
            return $"--> {this._review} (left from {this._user})\n";
        }
    }
}

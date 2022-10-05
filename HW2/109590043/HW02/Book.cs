namespace Homework02
{
    public class Book
    {
        private string _name;
        private string _id;
        private string _author;
        private string _publisher;
        public Book() 
        { 

        }

        public Book(string name, string id, string author, string publisher)
        {
            this._name = name;
            this._id = id;
            this._author = author;
            this._publisher = publisher;
        }

        //GetName
        public string GetName()
        {
            return this._name;
        }

        //SetName
        public void SetName(string name)
        {
            this._name = name;
        }

        //GetId
        public string GetId()
        {
            return this._id;
        }

        //SetId
        public void SetId(string id)
        {
            this._id = id;
        }

        //GetContent
        public string GetAuthor()
        {
            return this._author;
        }

        //SetContent
        public void SetAuthor(string author)
        {
            this._author = author;
        }

        //GetAddress
        public string GetPublisher()
        {
            return this._publisher;
        }

        //SetAddress
        public void SetPublisher(string publisher)
        {
            this._publisher = publisher;
        }

        //GetAllContent
        public string GetAllContent()
        {
            const string ID = "編號：";
            const string AUTHOR = "作者：";
            const string NEW_LINE = "\n";
            string content = this._name + NEW_LINE + ID + this._id + NEW_LINE + AUTHOR + this._author + NEW_LINE + this._publisher;
            return content;
        }

        //GetArray
        public string[] GetArray()
        {
            return new string[] { this._name, this._id, this._author, this._publisher };
        }
    }
}

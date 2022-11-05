using System.Drawing;

namespace Homework
{
    public class Book
    {
        private string _name;
        private string _id;
        private string _author;
        private string _publisher;
        private string _imageFile;
        public Book() 
        { 

        }

        public Book(string name, string id, string author, string publisher, string imageFile)
        {
            this._name = name;
            this._id = id;
            this._author = author;
            this._publisher = publisher;
            this._imageFile = imageFile;
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

        //GetImage
        public Image GetImage()
        {
            return Image.FromFile(_imageFile);
        }

        //SetImage
        public void SetImage(string imageFile)
        {
            this._imageFile = imageFile;
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
        public string[] GetDataGridViewArray()
        {
            const string ONE = "1";
            return new string[] { "", this._name, ONE, this._id, this._author, this._publisher };
        }

        //GetArray
        public string[] GetArray()
        {
            return new string[] { this._name, this._id, this._author, this._publisher, this._imageFile};
        }
    }
}

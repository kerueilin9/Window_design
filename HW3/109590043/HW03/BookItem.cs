namespace Homework
{
    public class BookItem
    {
        private int _bookCount;
        private Book _book;

        public BookItem()
        {

        }

        public BookItem(int bookCount, Book book)
        {
            this._bookCount = bookCount;
            this._book = book;
        }

        //GetBookCount
        public int GetBookCount()
        {
            return this._bookCount;
        }

        //SetBookCount
        public void SetBookCount(int bookCount)
        {
            this._bookCount = bookCount;
        }

        //GetBook
        public Book GetBook()
        {
            return this._book;
        }

        //SetBook
        public void SetBook(Book book)
        {
            this._book = book;
        }

        //SetPlusBookCount
        public void SetPlusBookCount(int plusBookCount)
        {
            this._bookCount += plusBookCount;
        }

        //SetMinusBookCount
        public void SetMinusBookCount(int minusBookCount)
        {
            this._bookCount -= minusBookCount;
        }
    }
}

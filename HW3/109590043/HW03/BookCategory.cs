using System;
using System.Collections.Generic;

namespace Homework
{
    public class BookCategory
    {
        private List<Book> _books;
        private string _categoryName;
        public BookCategory()
        {

        }

        public BookCategory(string categoryName)
        {
            this._categoryName = categoryName;
            this._books = new List<Book>();
        }
        
        public BookCategory(string categoryName, List<Book> books)
        {
            this._categoryName = categoryName;
            this._books = books;
        }

        //AddBook
        public void AddBook(Book book)
        {
            this._books.Add(book);
        }

        //GetCategoryName
        public string GetCategoryName()
        {
            return _categoryName;
        }

        //SetCategoryName
        public void SetCategoryName(string categoryName)
        {
            this._categoryName = categoryName;
        }

        //GetBooks
        public List<Book> GetBooks()
        {
            return this._books;
        }

        //GetBookCount
        public int GetBookCount()
        {
            return this._books.Count;
        }
    }
}

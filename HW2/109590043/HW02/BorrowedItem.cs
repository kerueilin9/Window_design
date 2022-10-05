using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02
{
    public class BorrowedItem
    {
        private DateTime _dateTime;
        private Book _book;
        public BorrowedItem()
        {

        }

        public BorrowedItem(DateTime dateTime, Book book)
        {
            this.DateTime = dateTime;
            this.Book = book;
        }

        public Book Book 
        { 
            get 
            { 
                return _book; 
            } 
            set 
            {
                _book = value; 
            } 
        }

        public DateTime DateTime 
        { 
            get 
            { 
                return _dateTime; 
            } 
            set 
            { 
                _dateTime = value; 
            } 
        }
    }
}

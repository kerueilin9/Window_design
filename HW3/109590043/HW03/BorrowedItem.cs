using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class BorrowedItem
    {
        private DateTime _dateTime;
        private Book _book;
        private const int ZERO = 0;
        private const int ONE = 1;
        private const int TWO = 2;
        private const int THREE = 3;
        private const int FOUR = 4;
        private const int FIVE = 5;
        private const int SIX = 6;
        private const int SEVEN = 7;
        private const int EIGHT = 8;
        private const int NINE = 9;

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

        //GetArray
        public string[] GetArray()
        {
            const string DATE_TYPE = "yyyy/MM/dd";
            string[] result = new string[NINE];
            result[ZERO] = "";
            result[ONE] = "";
            result[TWO] = _book.GetName();
            result[THREE] = ONE.ToString();
            result[FOUR] = _dateTime.ToString(DATE_TYPE);
            result[FIVE] = _dateTime.AddDays(SEVEN).ToString(DATE_TYPE);
            result[SIX] = _book.GetId();
            result[SEVEN] = _book.GetAuthor();
            result[EIGHT] = _book.GetPublisher();
            return result;
        }
    }
}

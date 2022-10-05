using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02
{
    public class BorrowedList
    {
        private List<BorrowedItem> _borrowedItems; 

        public BorrowedList()
        {
            this._borrowedItems = new List<BorrowedItem>();
        }
        //AddBorrowedList
        public void AddBorrowedList(BorrowedItem borrowedItem)
        {
            this._borrowedItems.Add(borrowedItem);
        }

        public List<BorrowedItem> BorrowedItems
        {
            get
            {
                return this._borrowedItems;
            }
            set
            {
                this._borrowedItems = value;
            }
        }
    }
}

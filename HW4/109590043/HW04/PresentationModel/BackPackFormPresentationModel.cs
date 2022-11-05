using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel
{
    public class BackPackFormPresentationModel
    {
        public event Action<string, string, int, int> _showMessage;
        private Model _model;

        public BackPackFormPresentationModel(Model model)
        {
            _model = model;
        }

        //ReturnList
        public List<string[]> ReturnList()
        {
            int sum = 1;
            const int INDEXER = 3;
            List<string[]> result = new List<string[]>();
            List<BorrowedItem> temp = new List<BorrowedItem>();
            string[] array;
            foreach (BorrowedItem borrowedItem in _model.GetBorrowedList())
            {
                if (temp.Count(ob => ob.Book == borrowedItem.Book && ob.GetDateTimeString() == borrowedItem.GetDateTimeString()) >= 1)
                    continue;
                temp.Add(borrowedItem);
                array = borrowedItem.GetArray();
                array[INDEXER] = _model.GetBorrowedList().FindAll(x => x.Book == borrowedItem.Book && x.GetDateTimeString() == borrowedItem.GetDateTimeString()).Count.ToString();
                result.Add(array);
            }
            return result;
        }

        //GetMessage
        public string GetMessage(string content, string count)
        {
            const string UPPER_BRACKET = "【";
            const string LAST_STRING = "】 已成功歸還{0}本";
            return UPPER_BRACKET + content + string.Format(LAST_STRING, count);
        }

        //GetMessageReturnLimit
        public void GetReturnLimitMessage(int rowIndex, int returnCount, int count)
        {
            const string TITLE = "還書錯誤";
            const string ZERO = "你至少歸還一本書";
            const string OVER = "還書數量不能超過已借數量";
            if (returnCount > count)
                ShowMessage(OVER, TITLE, rowIndex, count);
            else if (returnCount == 0)
                ShowMessage(ZERO, TITLE, rowIndex, 1);
        }

        //ShowMessage
        public void ShowMessage(string content, string title, int rowIndex, int resultCount)
        {
            if (this._showMessage != null)
                this._showMessage(content, title, rowIndex, resultCount);
        }
    }
}

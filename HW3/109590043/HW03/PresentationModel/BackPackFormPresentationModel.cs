using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel
{
    public class BackPackFormPresentationModel
    {
        private Model _model;

        public BackPackFormPresentationModel(Model model)
        {
            _model = model;
        }

        //ReturnList
        public List<string[]> ReturnList()
        {
            List<string[]> result = new List<string[]>();
            foreach (BorrowedItem borrowedItem in _model.GetBorrowedList())
            {
                //int sameBookCount = 1;
                //if (result.Contains(borrowedItem))
                result.Add(borrowedItem.GetArray());
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework02.PresentationModel
{
    internal class BookBorrowingFormPresentationModel
    {
        private List<bool> _visibleList = new List<bool>();
        private List<int> _currentPage = new List<int>();
        private Model _model;

        public BookBorrowingFormPresentationModel(Model model)
        {
            this._model = model;
            CreatePageList();
        }

        public void CreatePageList()
        {
            for(int i = 0; i < _model.GetBookCategories().Count; i++)
            {
                _currentPage.Add(1);
            }
        }
        
    }
}

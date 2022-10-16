using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel
{
    public class BookInventoryFormPresentationModel
    {
        private Model _model;

        public BookInventoryFormPresentationModel(Model model)
        {
            this._model = model;
        }

        public string GetContent(string name, string category, string count)
        {
            const string NAME_LABEL = "書籍名稱：";
            const string CATEGORY_LABEL = "書籍類別：";
            const string COUNT_LABEL = "庫存數量：";
            const string NEW_LINE = "\n";
            return NAME_LABEL + name + NEW_LINE + NEW_LINE + CATEGORY_LABEL + category + NEW_LINE + COUNT_LABEL + count;
        }
    }
}

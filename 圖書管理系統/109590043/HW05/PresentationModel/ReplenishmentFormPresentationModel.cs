using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel
{
    public class SupplementFormPresentationModel
    {
        private Model _model;

        public SupplementFormPresentationModel(Model model)
        {
            _model = model;
        }

        //ReturnCount
        public int ReturnCount(string number)
        {
            if (number == "")
                return 0;
            else
                return int.Parse(number);
        }
    }
}

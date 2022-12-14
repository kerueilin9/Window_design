using ClassLibrary;
using System.Windows.Forms;

namespace DrawingForm.PresentationModel
{
    public class FormPresentationModel
    {
        Model _model;
        public FormPresentationModel(Model model)
        {
            this._model = model;
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            _model.Draw(graphics);
        }
    }
}


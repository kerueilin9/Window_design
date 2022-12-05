using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Form1 : Form
    {
        ClassLibrary.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        Button _triangle = new Button();
        Button _rectangle = new Button();
        Button _clear = new Button();

        public Form1()
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            //
            // prepare clear button
            //
            _clear.Text = "Clear";
            _clear.Dock = DockStyle.Top;
            _clear.AutoSize = true;
            _clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _clear.Click += HandleClearButtonClick;
            Controls.Add(_clear);

            _rectangle.Text = "Rectangle";
            _rectangle.Dock = DockStyle.Top;
            _clear.AutoSize = true;
            _clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _rectangle.Click += ClickRectangle;
            Controls.Add(_rectangle);

            _triangle.Text = "Triangle";
            _triangle.Dock = DockStyle.Top;
            _clear.AutoSize = true;
            _clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _triangle.Click += ClickTriangle;
            Controls.Add(_triangle);
            //
            // prepare presentation model and model
            //
            _model = new ClassLibrary.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        //HandleClearButtonClick
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            this._triangle.Enabled = true;
            this._rectangle.Enabled = true;
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            this._triangle.Enabled = true;
            this._rectangle.Enabled = true;
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        //HandleCanvasPaint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //ClickRectangle
        public void ClickRectangle(object sender, System.EventArgs e)
        {
            _model.SetType(RECTANGLE);
            this._rectangle.Enabled = false;
            this._triangle.Enabled = true;
        }

        //ClickTriangle
        public void ClickTriangle(object sender, System.EventArgs e)
        {
            _model.SetType(TRIANGLE);
            this._triangle.Enabled = false;
            this._rectangle.Enabled = true;
        }

        //FormLoad
        private void FormLoad(object sender, EventArgs e)
        {

        }
    }
}

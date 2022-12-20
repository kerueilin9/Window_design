using DrawingForm.PresentationModel;
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
        ToolStripButton _undo;
        ToolStripButton _redo;

        DrawingModel.Model _model;
        PresentationModel.FormPresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";
        Button _triangle = new Button();
        Button _line = new Button();
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
            _rectangle.AutoSize = true;
            _rectangle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _rectangle.Click += ClickRectangle;
            Controls.Add(_rectangle);

            _line.Text = "Line";
            _line.Dock = DockStyle.Top;
            _line.AutoSize = true;
            _line.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _line.Click += ClickLine;
            Controls.Add(_line);

            _triangle.Text = "Triangle";
            _triangle.Dock = DockStyle.Top;
            _triangle.AutoSize = true;
            _triangle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            _triangle.Click += ClickTriangle;
            Controls.Add(_triangle);

            //
            // prepare presentation model and model
            //
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Parent = this;
            _undo = new ToolStripButton("Undo", null, UndoHandler);
            _undo.Enabled = false;
            toolStrip.Items.Add(_undo);
            _redo = new ToolStripButton("Redo", null, RedoHandler);
            _redo.Enabled = false;
            toolStrip.Items.Add(_redo);

            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.FormPresentationModel(_model);
            _model._modelChanged += HandleModelChanged;
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        //HandleClearButtonClick
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            this._triangle.Enabled = true;
            this._rectangle.Enabled = true;
            this._line.Enabled = true;
            RefreshEnabled();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
            RefreshEnabled();
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            this._triangle.Enabled = true;
            this._rectangle.Enabled = true;
            this._line.Enabled = _model.IsLineEnabled();
            RefreshEnabled();
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
            RefreshEnabled();
        }

        //HandleCanvasPaint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
            this._shapePosition.Text = _model.GetSelectedPosition();
        }

        //ClickRectangle
        public void ClickRectangle(object sender, System.EventArgs e)
        {
            _model.SetType(RECTANGLE);
            this._rectangle.Enabled = false;
            this._triangle.Enabled = true;
            this._line.Enabled = true;
        }

        //ClickLine
        public void ClickLine(object sender, System.EventArgs e)
        {
            _model.SetType(LINE);
            this._rectangle.Enabled = true;
            this._triangle.Enabled = true;
            this._line.Enabled = false;
        }

        //ClickTriangle
        public void ClickTriangle(object sender, System.EventArgs e)
        {
            _model.SetType(TRIANGLE);
            this._triangle.Enabled = false;
            this._rectangle.Enabled = true;
            this._line.Enabled = true;
        }

        //FormLoad
        private void FormLoad(object sender, EventArgs e)
        {

        }

        //UndoHandler
        void UndoHandler(Object sender, EventArgs e)
        {
            _model.Undo();
            RefreshEnabled();
        }

        //RedoHandler
        void RedoHandler(Object sender, EventArgs e)
        {
            _model.Redo();
            RefreshEnabled();
        }

        //RefreshUI
        void RefreshEnabled()
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            Invalidate();
        }
    }
}

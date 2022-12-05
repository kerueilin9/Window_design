using ClassLibrary;
using DrawingApp.PresentationModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DrawingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ClassLibrary.Model _model;
        PresentationModel.AppPresentationModel _presentationModel;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        //IGraphics _graphics;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new ClassLibrary.Model();
            _presentationModel = new PresentationModel.AppPresentationModel(_model, new AppGraphicsAdapter(_canvas));
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _rectangle.Click += ClickRectangle;
            _triangle.Click += ClickTriangle;
            _model._modelChanged += HandleModelChanged;
        }

        //HandleClearButtonClick
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            this._triangle.IsEnabled = true;
            this._rectangle.IsEnabled = true;
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            this._triangle.IsEnabled = true;
            this._rectangle.IsEnabled = true;
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //HandleCanvasMoved
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }

        //ClickRectangle
        public void ClickRectangle(object sender, RoutedEventArgs e)
        {
            _model.SetType(RECTANGLE);
            this._rectangle.IsEnabled = false;
            this._triangle.IsEnabled = true;
        }

        //ClickTriangle
        public void ClickTriangle(object sender, RoutedEventArgs e)
        {
            _model.SetType(TRIANGLE);
            this._triangle.IsEnabled = false;
            this._rectangle.IsEnabled = true;
        }
    }
}


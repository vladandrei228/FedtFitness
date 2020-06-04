using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace FedtFitness.View
{
    public sealed partial class CircleTimer : UserControl
    {
        private double ProgressValue = 0;

        public CircleTimer()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        #region Size Property
        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        private static void OnSizePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            CircleTimer TheControl = (source as CircleTimer);
            if (TheControl != null)
                TheControl.UpdateSizing();
        }
        public static readonly DependencyProperty SizeProperty =
         DependencyProperty.Register("Size", typeof(double), typeof(CircleTimer), new PropertyMetadata((double)28.0, OnSizePropertyChanged));

        private double InsideSize { get { return Size - LineWidth; } }
        private double HalfInsideSize { get { return (Size - LineWidth) / 2; } }
        #endregion Size Property

        #region LineWidth
        public double LineWidth
        {
            get { return (double)GetValue(LineWidthProperty); }
            set { SetValue(LineWidthProperty, value); }
        }
        public static readonly DependencyProperty LineWidthProperty =
            DependencyProperty.Register("LineWidth", typeof(double), typeof(CircleTimer), new PropertyMetadata((double)4.0, OnLineWidthPropertyChanged));

        private static void OnLineWidthPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            CircleTimer TheControl = (source as CircleTimer);
            if (TheControl != null)
                TheControl.UpdateSizing();
        }
        #endregion LineWidth
        #region Color
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("LineWidth", typeof(Brush), typeof(CircleTimer), new PropertyMetadata(new SolidColorBrush(Colors.White), OnColorPropertyChanged));

        private static void OnColorPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            CircleTimer TheControl = (source as CircleTimer);
            if (TheControl != null)
                TheControl.UpdateSizing();
        }
        #endregion Color

        private void UpdateSizing()
        {
            ThePath.Stroke = Color;
            ThePath.StrokeThickness = LineWidth;
            TheGrid.Width = Size;
            TheGrid.Height = Size;
            ThePathFigure.StartPoint = new Point(HalfInsideSize, InsideSize);
            TheSegment.Size = new Windows.Foundation.Size(HalfInsideSize, HalfInsideSize);
            SetBarLength(ProgressValue);
        }
        private void SetBarLengthUI(double Value)
        {
            Value = Math.Max(0, Math.Min(1.0, Value));
            ProgressValue = Value;

            double Angle = 2 * 3.14159265 * ProgressValue;

            double X = HalfInsideSize - Math.Sin(Angle) * HalfInsideSize;
            double Y = HalfInsideSize + Math.Cos(Angle) * HalfInsideSize;

            if (Value > 0 && (int)X == HalfInsideSize && (int)Y == InsideSize)
                X += 0.01;

            TheSegment.IsLargeArc = Angle >= 3.14159265;
            TheSegment.Point = new Point(X, Y);
        }

        public void SetBarLength(double Value)
        {
            if (DesignMode.DesignModeEnabled)
                SetBarLengthUI(Value);
            else if (CoreApplication.MainView.CoreWindow.Dispatcher.HasThreadAccess)
                SetBarLengthUI(Value);
            else
            {
                double LocalValue = Value;
                IAsyncAction IgnoreMe = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { SetBarLengthUI(Value); });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFZadanie4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Rectangle lastRec = null;
        public MainWindow()
        {
            InitializeComponent();
            canvas.Background = Brushes.White;
            canvas.Focus();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (lastRec != null)
                {
                    Point p = e.GetPosition(this);
                    double height = p.Y - (double)lastRec.GetValue(Canvas.TopProperty);
                    double width = p.X - (double)lastRec.GetValue(Canvas.LeftProperty);
                    if (height > 0)
                    {
                        if (height < (double)lastRec.GetValue(Canvas.TopProperty) + lastRec.Height - p.Y)
                        {
                            lastRec.SetValue(Canvas.TopProperty, p.Y);
                            lastRec.Height += -height;
                        }
                        else
                            lastRec.Height = height;
                    }
                    else
                    {
                        lastRec.SetValue(Canvas.TopProperty, p.Y);
                        lastRec.Height += -height;
                    }
                    if (width > 0)
                    {
                        if (width < (double)lastRec.GetValue(Canvas.LeftProperty) + lastRec.Width - p.X)
                        {
                            lastRec.SetValue(Canvas.LeftProperty, p.X);
                            lastRec.Width += -width;
                        }
                        else
                            lastRec.Width = width;
                    }
                    else
                    {
                        lastRec.SetValue(Canvas.LeftProperty, p.X);
                        lastRec.Width += -width;
                    }
                }
            }
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(canvas);
            Rectangle r = new Rectangle();
            lastRec = r;
            Point p = e.GetPosition(this);
            r.SetValue(Canvas.TopProperty, p.Y);
            r.SetValue(Canvas.LeftProperty, p.X);

            r.Width = 0;
            r.Height = 0;

            r.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            canvas.Children.Add(r);
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (lastRec == null)
                return;

            switch (e.Key)
            {
                case Key.Up:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Shift)
                        {
                            lastRec.SetValue(Canvas.TopProperty, (double)lastRec.GetValue(Canvas.TopProperty) - 1.0);
                            lastRec.Height += 1.0;
                        }
                        else
                            lastRec.SetValue(Canvas.TopProperty, (double)lastRec.GetValue(Canvas.TopProperty) - 1.0);
                        break;
                    }
                case Key.Down:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Shift)
                            lastRec.Height += 1.0;
                        else
                            lastRec.SetValue(Canvas.TopProperty, (double)lastRec.GetValue(Canvas.TopProperty) + 1.0);
                        break;
                    }
                case Key.Left:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Shift)
                        {
                            lastRec.SetValue(Canvas.LeftProperty, (double)lastRec.GetValue(Canvas.LeftProperty) - 1.0);
                            lastRec.Width += 1.0;
                        }
                        else
                            lastRec.SetValue(Canvas.LeftProperty, (double)lastRec.GetValue(Canvas.LeftProperty) - 1.0);
                        break;
                    }
                case Key.Right:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Shift)
                            lastRec.Width += 1.0;
                        else
                            lastRec.SetValue(Canvas.LeftProperty, (double)lastRec.GetValue(Canvas.LeftProperty) + 1.0);
                        break;
                    }
            }

        }
    }
}

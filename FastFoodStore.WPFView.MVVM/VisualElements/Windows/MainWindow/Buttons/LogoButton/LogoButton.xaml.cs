using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Buttons.LogoButton
{
    public partial class LogoButton : UserControl
    {
        public LogoButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(App.Current.MainWindow.WindowState == WindowState.Maximized) 
            {
                App.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                App.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void LogoImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                App.Current.MainWindow.DragMove();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            rnd.Next(0, 256);
            Color colorForegroundFont = Color.FromRgb((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256));
            Color colorBackgroundButton = Color.FromRgb((byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256), (byte)rnd.Next(0, 256));
            App.Current.Resources["ValueColorForegroundFont"] = new SolidColorBrush(colorForegroundFont);
            App.Current.Resources["ValueColorBackgroundButton"] = new SolidColorBrush(colorBackgroundButton);
        }
    }
}

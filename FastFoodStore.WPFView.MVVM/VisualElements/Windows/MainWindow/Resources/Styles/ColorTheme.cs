using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Resources.Styles
{
    public class ColorTheme
    {
        public SolidColorBrush ColorForegroundFont { get; set; }

        public SolidColorBrush ColorBackgroundFont { get; set; }

        public ColorTheme() 
        {
            ColorForegroundFont = (SolidColorBrush)App.Current.Resources["ValueColorForegroundFont"];
            ColorBackgroundFont = (SolidColorBrush)App.Current.Resources["ValueColorBackgroundButton"];
        }
    }
}

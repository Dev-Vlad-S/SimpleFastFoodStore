using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Buttons.LogoButton;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.TopProductsPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Resources.Styles;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FastFoodStore.WPFView.MVVM.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private ColorTheme colorTheme;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
            colorTheme = new ColorTheme();
            App.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void StoreWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            App.Current.Resources["ValueFontSize"] = this.Width * 0.015;

            Image? img = (this.FindName("BtnLogo") as LogoButton).LogoImg;

            TopProductsPanel topProductsPanel = (TopProductsPanel)((MainVM)this.DataContext).TopProductsPanel;
            foreach (var topprod in topProductsPanel.UIgridTopPanel.Children)
            {
                if (topprod != null && topprod is TemplateCardProductProductsPanels card)
                {
                    card.Width = img.ActualWidth;
                }
            }
        }

        private void StoreWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show(
                    owner: this,
                    messageBoxText: "Вы действительно хотите закрыть приложение магазина?",
                    caption: "Окно закрытия магазина",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Stop);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            colorTheme.ColorForegroundFont = (SolidColorBrush)App.Current.Resources["ValueColorForegroundFont"];
            colorTheme.ColorBackgroundFont = (SolidColorBrush)App.Current.Resources["ValueColorBackgroundButton"];
            string str = System.Windows.Markup.XamlWriter.Save(colorTheme);
            File.WriteAllText("ColorTheme", str);
        }

        private void StoreWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("ColorTheme")) return;
            string str = File.ReadAllText("ColorTheme");
            if (System.Windows.Markup.XamlReader.Parse(str) is ColorTheme)
            {
                colorTheme = (ColorTheme)System.Windows.Markup.XamlReader.Parse(str);
                App.Current.Resources["ValueColorForegroundFont"] = colorTheme.ColorForegroundFont;
                App.Current.Resources["ValueColorBackgroundButton"] = colorTheme.ColorBackgroundFont;
            }
        }
    }
}
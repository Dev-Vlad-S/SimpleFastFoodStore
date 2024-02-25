using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Buttons.LogoButton;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using System.Windows.Controls;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.TopProductsPanel
{
    public partial class TopProductsPanel : UserControl
    {

        public TopProductsPanel(MainVM mainVM)
        {
            InitializeComponent();
            foreach(var prod in mainVM.CollectionTopProducts)
            {
                TemplateCardProductProductsPanels cardProductProductsPanels = new TemplateCardProductProductsPanels(prod, mainVM.VMBasket);
                Image? img = (App.Current.MainWindow.FindName("BtnLogo") as LogoButton).LogoImg;
                cardProductProductsPanels.Width = img.ActualWidth;
                UIgridTopPanel.Children.Add(cardProductProductsPanels);
            }
        }
    }
}

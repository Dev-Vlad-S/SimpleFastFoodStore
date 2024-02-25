using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using System.Collections.ObjectModel;
using System.Windows.Controls;


namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.SaucesPanel
{
    public partial class SaucesPanel : UserControl
    {
        private ObservableCollection<ProductWPF> saucesProductsWPF;

        public SaucesPanel(ObservableCollection<ProductWPF> productsWPF, VMBasket vMBasket)
        {
            InitializeComponent();

            saucesProductsWPF = new ObservableCollection<ProductWPF>(productsWPF.Where(prod => prod.WPF_Product_Tag == "Sauces"));
            foreach (ProductWPF product in saucesProductsWPF)
            {
                WrapLayoutSaucesProductsWPF.Children.Add(new TemplateCardProductProductsPanels(product, vMBasket));
            }
        }
    }
}

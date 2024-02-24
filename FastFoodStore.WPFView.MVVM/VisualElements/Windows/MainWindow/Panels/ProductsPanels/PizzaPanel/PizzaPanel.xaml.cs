using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.PizzaPanel
{
    public partial class PizzaPanel : UserControl
    {
        private ObservableCollection<ProductWPF> pizzaProductsWPF;

        public PizzaPanel(ObservableCollection<ProductWPF> productsWPF, VMBasket vMBasket)
        {
            InitializeComponent();

            pizzaProductsWPF = new ObservableCollection<ProductWPF>(productsWPF.Where(prod => prod.WPF_Product_Tag == "Pizza"));
            foreach (ProductWPF product in pizzaProductsWPF)
            {
                WrapLayoutPizzaProductsWPF.Children.Add(new TemplateCardProductProductsPanels(product, vMBasket));
            }
        }
    }
}

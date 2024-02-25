using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.SnacksPanel
{
    public partial class SnacksPanel : UserControl
    {
        private ObservableCollection<ProductWPF> snacksProductsWPF;

        public SnacksPanel(ObservableCollection<ProductWPF> productsWPF, VMBasket vMBasket)
        {
            InitializeComponent();

            snacksProductsWPF = new ObservableCollection<ProductWPF>(productsWPF.Where(prod => prod.WPF_Product_Tag == "Snacks"));
            foreach (ProductWPF product in snacksProductsWPF)
            {
                WrapLayoutSnacksProductsWPF.Children.Add(new TemplateCardProductProductsPanels(product, vMBasket));
            }
        }
    }
}

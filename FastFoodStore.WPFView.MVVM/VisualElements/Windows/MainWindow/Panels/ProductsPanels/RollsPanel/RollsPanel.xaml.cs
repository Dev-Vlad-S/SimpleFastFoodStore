using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.RollsPanel
{
    public partial class RollsPanel : UserControl
    {
        private ObservableCollection<ProductWPF> rollsProductsWPF;

        public RollsPanel(ObservableCollection<ProductWPF> productsWPF, VMBasket vMBasket)
        {
            InitializeComponent();

            rollsProductsWPF = new ObservableCollection<ProductWPF>(productsWPF.Where(prod => prod.WPF_Product_Tag == "Roll"));
            foreach (ProductWPF product in rollsProductsWPF)
            {
                WrapLayoutRollsProductsWPF.Children.Add(new TemplateCardProductProductsPanels(product, vMBasket));
            }
        }
    }
}

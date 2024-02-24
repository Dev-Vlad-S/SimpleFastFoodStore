using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
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

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelWithoutProducts
{
    public partial class EmptyBasketsPanelWithoutProducts : UserControl
    {
        public EmptyBasketsPanelWithoutProducts(VMBasket vmBasket)
        {
            InitializeComponent();
        }
    }
}

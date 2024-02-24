using FastFoodStore.BLL;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.MappersWPFView;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Buttons.LogoButton;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

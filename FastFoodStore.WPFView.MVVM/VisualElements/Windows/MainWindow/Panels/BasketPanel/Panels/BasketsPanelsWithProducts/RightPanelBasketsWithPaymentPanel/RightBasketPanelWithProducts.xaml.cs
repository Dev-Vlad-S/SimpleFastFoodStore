using FastFoodStore.BLL;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.MappersWPFView;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.TopProductsPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Buttons.LogoButton;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Resources.Styles;
using System.Windows.Media;
using System.Windows;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts.RightPanelBasketsWithPaymentPanel
{
    public partial class RightBasketPanelWithProducts : UserControl
    {
        public VMBasket vmBasket;
        private MainVM mainVM;
        public RightBasketPanelWithProducts(MainVM mainVM)
        {
            InitializeComponent();
            this.vmBasket = mainVM.VMBasket;
            DataContext = this.vmBasket;
            this.mainVM = mainVM;
        }

        private void CanExecuteStartRegistrationOrder(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (vmBasket.BasketProductsForPayment.Count > 0)
            {
                e.CanExecute = true;
            }
        }

        private void ExecuteStartRegistrationOrder(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var result = MessageBox.Show(
                   messageBoxText: "Вы действительно хотите купить выбранный товар?",
                   caption: "Окно подтверждения",
                   button: MessageBoxButton.YesNo,
                   icon: MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            UpdateSourceData:
            foreach (var prod in vmBasket.BasketProductsForPayment)
            {
                if (vmBasket.MainVM.SourceData.UpdatePurchasedCountProductsInDataSource(MapperProduct.MapProductDown(prod)))
                {
                    vmBasket.BasketProductsForPayment.Remove(prod);
                }
                goto UpdateSourceData;
            }
            vmBasket.IsStatusProducts = true;
            if (vmBasket.BasketProducts.Count > 0)
            {
                vmBasket.BasketProducts.Clear();
            }
            vmBasket.IsStatusProducts = false;

            mainVM.CollectionTopProducts.Clear();
            mainVM.InitializeDataTopProductsPanel();
            mainVM.TopProductsPanel = new TopProductsPanel.TopProductsPanel(mainVM);
        }
    }
}

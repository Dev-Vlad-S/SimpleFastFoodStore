using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelWithoutProducts;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel
{
    public partial class BasketPanel : UserControl
    {
        private BasketsPanelWithProducts basketsPanelWithProducts;
        private EmptyBasketsPanelWithoutProducts basketPanelWithoutProducts;
        private BasketsPanelAfterPayment basketsPanelAfterPayment;
        private VMBasket vmBasket;

        public BasketsPanelWithProducts BasketsPanelWithProducts { get => basketsPanelWithProducts; }
        public EmptyBasketsPanelWithoutProducts EmptyBasketsPanelWithoutProducts { get => basketPanelWithoutProducts; }
        public BasketsPanelAfterPayment BasketsPanelAfterPayment { get => basketsPanelAfterPayment; }
        public BasketPanel(MainVM mainVM)
        {
            InitializeComponent();
            this.vmBasket = mainVM.VMBasket;
            basketsPanelWithProducts = new BasketsPanelWithProducts(mainVM);
            basketPanelWithoutProducts = new EmptyBasketsPanelWithoutProducts(this.vmBasket);
            basketsPanelAfterPayment = new BasketsPanelAfterPayment(this.vmBasket);
        
            this.vmBasket.BasketProducts.CollectionChanged += OnChangeListProducts;
        }

        private void OnChangeListProducts(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (vmBasket.BasketProducts.Count > 0)
            {
                VisualContentBasket.Content = basketsPanelWithProducts;
            }
            else
            {
                if (vmBasket.IsStatusProducts)
                {
                    basketsPanelWithProducts.LeftBasketPanelWithProducts.StackPotentilyBoughtProducts.Children.Clear();
                    VisualContentBasket.Content = basketsPanelAfterPayment;
                }
                else
                {
                    VisualContentBasket.Content = basketPanelWithoutProducts;
                }
            }
        }
    }
}


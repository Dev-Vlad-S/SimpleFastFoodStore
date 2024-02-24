using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts.LeftPanelBasketsWithPotentialyBoughtProducts;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts.RightPanelBasketsWithPaymentPanel;
using System.Windows.Controls;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts
{
    public partial class BasketsPanelWithProducts : UserControl
    {
        private LeftBasketPanelWithProducts leftBasketsPanelWithPotentialyBoughtProducts;
        private RightBasketPanelWithProducts rightBasketsPanelWithPotentialyBoughtProducts;

        public LeftBasketPanelWithProducts LeftBasketPanelWithProducts { get => leftBasketsPanelWithPotentialyBoughtProducts; } 

        public BasketsPanelWithProducts(MainVM mainVM)
        {
            InitializeComponent();
            leftBasketsPanelWithPotentialyBoughtProducts = new LeftBasketPanelWithProducts(mainVM.VMBasket);
            rightBasketsPanelWithPotentialyBoughtProducts = new RightBasketPanelWithProducts(mainVM);
            LeftContentBasketsPanelWithProducts.Content = leftBasketsPanelWithPotentialyBoughtProducts;
            RightContentBasketsPanelForPayment.Content = rightBasketsPanelWithPotentialyBoughtProducts;
        }
    }
}

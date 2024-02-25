using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts.LeftPanelBasketsWithProducts.TemplateCardProductInBasket;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts.LeftPanelBasketsWithPotentialyBoughtProducts
{
    public partial class LeftBasketPanelWithProducts : UserControl
    {
        private VMBasket vmBasket;
        public LeftBasketPanelWithProducts(VMBasket vmBasket)
        {
            InitializeComponent();
            this.vmBasket = vmBasket;
            this.vmBasket.BasketProducts.CollectionChanged += OnAddPotentialyBoughtProduct;
        }

        private void OnAddPotentialyBoughtProduct(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var prod in vmBasket.BasketProducts)
                {
                    bool isExist = false;
                    foreach (var existedElement in StackPotentilyBoughtProducts.Children)
                    {
                        if (((CardProductsInBasket)existedElement).productWPF.WPF_Product_Name == prod.WPF_Product_Name)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        CardProductsInBasket cardProductsInBasket = new CardProductsInBasket(vmBasket, prod);
                        StackPotentilyBoughtProducts.Children.Add(cardProductsInBasket);
                        cardProductsInBasket.IsChecked = true;
                        Binding binding = new Binding();
                        binding.ElementName = "CheckBoxSelectAll";
                        binding.Path = new PropertyPath("IsChecked");
                        binding.Mode = BindingMode.OneWay;
                        cardProductsInBasket.SetBinding(CardProductsInBasket.IsCheckedProperty, binding);
                    }
                }
            }
        }

        private void CanDeleteSelectedProductsFromBasketInBasket(object sender, CanExecuteRoutedEventArgs e)
        {
            if (CheckBoxSelectAll.IsChecked == true)
            {
                e.CanExecute = true;
            }
            foreach (var cardPotentialyBoughtProduct in StackPotentilyBoughtProducts.Children)
            {
                if (cardPotentialyBoughtProduct is CardProductsInBasket cardProductsInBasket)
                {
                    if (cardProductsInBasket.IsChecked == true)
                    {
                        e.CanExecute = true;
                    }
                }
            }
        }

        private void DeleteSelectedProductsFromBasket(object sender, ExecutedRoutedEventArgs e)
        {
            UpdateProducts:
            foreach (var cardPotentialyBoughtProduct in StackPotentilyBoughtProducts.Children)
            {
                if (cardPotentialyBoughtProduct is CardProductsInBasket basketsCardPotentialyBoughtProduct)
                {
                    if (basketsCardPotentialyBoughtProduct.IsChecked == true)
                    {
                        foreach (var product in vmBasket.BasketProducts)
                        {
                            if (basketsCardPotentialyBoughtProduct.TxtBlockProductName.Text == product.WPF_Product_Name)
                            {
                                foreach (var prod in vmBasket.BasketProductsForPayment)
                                {
                                    if (product.WPF_Product_Name == prod.WPF_Product_Name)
                                    {
                                        basketsCardPotentialyBoughtProduct.IsChecked = false;
                                        vmBasket.BasketProductsForPayment.Remove(prod);
                                        break;
                                    }
                                }
                                vmBasket.BasketProducts.Remove(product);
                                StackPotentilyBoughtProducts.Children.Remove(basketsCardPotentialyBoughtProduct);
                                goto UpdateProducts;
                            }
                        }
                    }
                }
            }
        }
    }
}

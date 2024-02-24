using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel.Panels.BasketsPanelsWithProducts.LeftPanelBasketsWithProducts.TemplateCardProductInBasket
{
    public partial class CardProductsInBasket : CheckBox
    {
        private VMBasket vmBasket;
        public ProductWPF productWPF;
        private ProductWPF cardProduct;
        bool isActive;

        public CardProductsInBasket(VMBasket vmBasket, ProductWPF productWPF)
        {
            InitializeComponent();
            this.vmBasket = vmBasket;
            cardProduct = new ProductWPF()
            {
                WPF_Product_ImagePath = productWPF.WPF_Product_ImagePath,
                WPF_Product_Name = productWPF.WPF_Product_Name,
                WPF_Product_Descriptiont = productWPF.WPF_Product_Descriptiont,
                WPF_Product_Price = productWPF.WPF_Product_Price,
                WPF_Product_CountInBasket = productWPF.WPF_Product_CountInBasket
            };
            this.vmBasket = vmBasket;
            this.productWPF = productWPF;
            cardProduct.WPF_Product_ImagePath = $"/VisualElements/Windows/MainWindow/Panels/ProductsPanels/{productWPF.WPF_Product_ImagePath}";
            this.DataContext = cardProduct;
            this.IsChecked = true;
        }

        private void OnSelectedCardPotentialyBoughtProduct(object sender, RoutedEventArgs e)
        {
            ChangeStatus(true);
            gridCountBoughtProducts.Visibility = Visibility.Visible;
            Frame.Background = new SolidColorBrush(Colors.Green);
        }

        private void OnUnSelectedCardPotentialyBoughtProduct(object sender, RoutedEventArgs e)
        {
            ChangeStatus(false);
            gridCountBoughtProducts.Visibility = Visibility.Collapsed;
            Frame.Background = new SolidColorBrush(Colors.OrangeRed);
        }

        private void ChangeStatus(bool status)
        {
            if (status)
            {
                vmBasket.BasketProductsForPayment.Add(productWPF);
            }
            else
            {
                vmBasket.BasketProductsForPayment.Remove(productWPF);
            }

            vmBasket.ReCalculatePriceBoughtProducts();
            vmBasket.ReCalculateCountBoughtProducts();
        }

        private void CanExecuteDecreaseCountBoughtProduct(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.IsChecked == true)
            {
                foreach (var prod in vmBasket.BasketProductsForPayment)
                {
                    if (prod.WPF_Product_Name == cardProduct.WPF_Product_Name)
                    {
                        if (prod.WPF_Product_CountInBasket <= 10 && prod.WPF_Product_CountInBasket > 1)
                        {
                            BtnDecreaseCountBoughtProduct.Visibility = Visibility.Visible;
                            e.CanExecute = true;
                        }
                        else
                        {
                            e.CanExecute = false;
                            BtnDecreaseCountBoughtProduct.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }

        }


        private void DecreaseCountBoughtProduct(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (var prod in vmBasket.BasketProductsForPayment)
            {
                if (prod.WPF_Product_Name == cardProduct.WPF_Product_Name)
                {
                    --prod.WPF_Product_CountInBasket;
                    TxtBlockCountBoughtProduct.Text = prod.WPF_Product_CountInBasket.ToString();
                }
            }
            vmBasket.ReCalculatePriceBoughtProducts();
            vmBasket.ReCalculateCountBoughtProducts();
        }

        private void CanExecuteIncreaseCountBoughtProduct(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.IsChecked == true)
            {
                foreach (var prod in vmBasket.BasketProductsForPayment)
                {
                    if (prod.WPF_Product_Name == cardProduct.WPF_Product_Name)
                    {
                        if (prod.WPF_Product_CountInBasket < 10)
                        {
                            BtnIncreaseCountBoughtProduct.Visibility = Visibility.Visible;
                            e.CanExecute = true;
                        }
                        else
                        {
                            e.CanExecute = false;
                            BtnIncreaseCountBoughtProduct.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        private void IncreaseCountBoughtProduct(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (var prod in vmBasket.BasketProductsForPayment)
            {
                if (prod.WPF_Product_Name == cardProduct.WPF_Product_Name)
                {
                    ++prod.WPF_Product_CountInBasket;
                    TxtBlockCountBoughtProduct.Text = prod.WPF_Product_CountInBasket.ToString();
                }
            }
            vmBasket.ReCalculatePriceBoughtProducts();
            vmBasket.ReCalculateCountBoughtProducts();
        }

        private void CheckBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Frame.BorderBrush = new SolidColorBrush(Colors.Orange);
        }

        private void CheckBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Frame.BorderBrush = new SolidColorBrush(Colors.Orange);
        }

        private void CheckBox_MouseLeave(object sender, MouseEventArgs e)
        {
            Frame.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}

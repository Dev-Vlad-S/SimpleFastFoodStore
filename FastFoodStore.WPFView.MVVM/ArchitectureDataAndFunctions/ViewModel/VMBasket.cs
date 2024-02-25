using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel
{
    public class VMBasket : VMBaseModelNotifyUserControls, INotifyCollectionChanged
    {
        public ObservableCollection<ProductWPF> BasketProducts { get; set; }
        public ObservableCollection<ProductWPF> BasketProductsForPayment { get; set; }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        private string countProductsInBasket;
        public string CountProductsInBasket
        {
            get { return countProductsInBasket; }
            set { countProductsInBasket = value; OnPropertyChanged(nameof(CountProductsInBasket)); }
        }

        private string priceBoughtProducts;
        public string PriceBoughtProducts
        {
            get { return priceBoughtProducts; }
            set { priceBoughtProducts = value; OnPropertyChanged(nameof(PriceBoughtProducts)); }
        }

        private string countBoughtProducts;
        public string CountBoughtProducts
        {
            get { return countBoughtProducts; }
            set { countBoughtProducts = value; OnPropertyChanged(nameof(CountBoughtProducts)); }
        }

        public MainVM MainVM { get; private set; }

        public bool IsStatusProducts { get; set; }

        public VMBasket(MainVM mainVM)
        {
            MainVM = mainVM;
            countProductsInBasket = String.Empty;
            BasketProducts = new ObservableCollection<ProductWPF>();
            BasketProductsForPayment = new ObservableCollection<ProductWPF>();
            BasketProducts.CollectionChanged += OnChangeCountProducts;
            IsStatusProducts = false;
        }

        private void OnChangeCountProducts(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (BasketProducts.Count > 0)
            {
                CountProductsInBasket = BasketProducts.Count.ToString();
            }
            else
            {
                CountProductsInBasket = String.Empty;
            };
        }

        public void ReCalculatePriceBoughtProducts()
        {
            double tempPriceBoughtProducts = 0;
            foreach (var prod in BasketProductsForPayment)
            {
                double tempPrice = prod.WPF_Product_CountInBasket * prod.WPF_Product_Price;
                tempPriceBoughtProducts += tempPrice;
            }
            PriceBoughtProducts = tempPriceBoughtProducts.ToString();
        }

        public void ReCalculateCountBoughtProducts()
        {
            int tempCountBoughtProducts = 0;
            foreach (var prod in BasketProductsForPayment)
            {
                tempCountBoughtProducts += prod.WPF_Product_CountInBasket;
            }
            CountBoughtProducts = tempCountBoughtProducts.ToString() + " " + EndingCountBoughtProducts(tempCountBoughtProducts);
        }

        private string EndingCountBoughtProducts(int countBoughtProducts)
        {
            if ((countBoughtProducts % 10 == 0) || (countBoughtProducts % 10 > 4 && countBoughtProducts % 10 < 10) || (countBoughtProducts > 9 && countBoughtProducts < 20)) return "товаров";
            if (countBoughtProducts % 10 == 1) return "товар";
            return "товара";
        }
    }
}


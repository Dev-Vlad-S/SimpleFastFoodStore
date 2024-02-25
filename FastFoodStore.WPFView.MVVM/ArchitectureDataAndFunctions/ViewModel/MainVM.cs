using FastFoodStore.BLL;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.MappersWPFView;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.BasketPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.PizzaPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.RollsPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.SaucesPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.SnacksPanel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.TopProductsPanel;
using System.Collections.ObjectModel;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel
{
    public class MainVM : VMBaseModelNotifyUserControls
    {
        private PizzaPanel pizzaPanel;
        public PizzaPanel PizzaPanel { get => pizzaPanel; }
        private SaucesPanel saucesPanel;
        public SaucesPanel SaucesPanel { get => saucesPanel; }
        private RollsPanel rollsPanel;
        public RollsPanel RollsPanel { get => rollsPanel; }
        private SnacksPanel snacksPanel;
        public SnacksPanel SnacksPanel { get => snacksPanel; }
        private BasketPanel basketPanel;
        public BasketPanel BasketPanel { get => basketPanel; set => basketPanel = value; }

        private VMNavigation vmNavigation;
        public VMNavigation VMNavigation { get => vmNavigation; set => vmNavigation = value; }

        private object selectedProductPanel;
        public object SelectedProductPanel
        {
            get { return selectedProductPanel; }
            set { selectedProductPanel = value;  OnPropertyChanged(nameof(SelectedProductPanel)); }
        }

        private SourceData sourceData;
        public SourceData SourceData { get => sourceData; }

        private ObservableCollection<ProductWPF> productsWPF;
        public ObservableCollection<ProductWPF> ProductsWPF { get; set; }

        private VMBasket vmBasket;
        public VMBasket VMBasket { get=>vmBasket;}

        private object topProductsPanel;
        public object TopProductsPanel
        {
            get { return topProductsPanel; }
            set { topProductsPanel = value; OnPropertyChanged(nameof(TopProductsPanel)); }
        }

        private ObservableCollection<ProductWPF> collectionTopProducts;
        public ObservableCollection<ProductWPF> CollectionTopProducts { get => collectionTopProducts; set { collectionTopProducts=value; } }

        public MainVM()
        {
            sourceData = new SourceData();
            productsWPF = new ObservableCollection<ProductWPF>((sourceData.GetAllProductsFromDB()).Select(MapperProduct.MapProductUp).ToList());
            vmBasket = new VMBasket(this);
            pizzaPanel = new PizzaPanel(productsWPF, vmBasket);
            saucesPanel = new SaucesPanel(productsWPF, vmBasket);
            rollsPanel = new RollsPanel(productsWPF, vmBasket);
            snacksPanel = new SnacksPanel(productsWPF, vmBasket);
            basketPanel = new BasketPanel(this);
            vmNavigation = new VMNavigation(this);
            InitializeDataTopProductsPanel();
            topProductsPanel = new TopProductsPanel(this);
        }

        public void InitializeDataTopProductsPanel()
        {
            var dataSource = new SourceData();
            var products = new ObservableCollection<ProductWPF>((dataSource.GetAllProductsFromDB()).Select(MapperProduct.MapProductUp).ToList());
            var  lstIntermediate = new List<ProductWPF>(products.OrderByDescending(prod => prod.WPF_Product_PurchasedCount).Take(3).ToList());
            collectionTopProducts = new ObservableCollection<ProductWPF>();

            collectionTopProducts.Add(new ProductWPF()
            { 
                WPF_Product_ImagePath = lstIntermediate[0].WPF_Product_ImagePath, 
                WPF_Product_Name = lstIntermediate[0].WPF_Product_Name,
                WPF_Product_Descriptiont = lstIntermediate[0].WPF_Product_Descriptiont,
                WPF_Product_Price = lstIntermediate[0].WPF_Product_Price
            });

            collectionTopProducts.Add(new ProductWPF()
            {
                WPF_Product_ImagePath = lstIntermediate[1].WPF_Product_ImagePath,
                WPF_Product_Name = lstIntermediate[1].WPF_Product_Name,
                WPF_Product_Descriptiont = lstIntermediate[1].WPF_Product_Descriptiont,
                WPF_Product_Price = lstIntermediate[1].WPF_Product_Price
            });

            collectionTopProducts.Add(new ProductWPF()
            {
                WPF_Product_ImagePath = lstIntermediate[2].WPF_Product_ImagePath,
                WPF_Product_Name = lstIntermediate[2].WPF_Product_Name,
                WPF_Product_Descriptiont = lstIntermediate[2].WPF_Product_Descriptiont,
                WPF_Product_Price = lstIntermediate[2].WPF_Product_Price
            });
        }
    }
}

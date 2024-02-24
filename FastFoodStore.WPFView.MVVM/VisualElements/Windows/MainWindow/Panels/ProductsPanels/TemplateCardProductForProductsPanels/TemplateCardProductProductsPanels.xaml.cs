using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.Models;
using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel;
using FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Buttons.BasketButton;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace FastFoodStore.WPFView.MVVM.VisualElements.Windows.MainWindow.Panels.ProductsPanels.TemplateCardProductForProductsPanels
{
    public partial class TemplateCardProductProductsPanels : RadioButton
    {
        private ProductWPF productWPF;
        private VMBasket vmBasket;
        private ProductWPF cardProduct;


        public TemplateCardProductProductsPanels(ProductWPF productWPF, VMBasket vmBasket)
        {
            cardProduct = new ProductWPF()
            {
                WPF_Product_ImagePath = productWPF.WPF_Product_ImagePath,
                WPF_Product_Name = productWPF.WPF_Product_Name,
                WPF_Product_Descriptiont = productWPF.WPF_Product_Descriptiont,
                WPF_Product_Price = productWPF.WPF_Product_Price
            };
            this.productWPF = productWPF;
            cardProduct.WPF_Product_ImagePath = $"/VisualElements/Windows/MainWindow/Panels/ProductsPanels/{productWPF.WPF_Product_ImagePath}";
            this.vmBasket = vmBasket;
            InitializeComponent();
            DataContext = cardProduct;
        }

        private void CanExecuteAddProductFromPanelInBasket(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            bool isCan = true;
            foreach (var prod in vmBasket.BasketProducts)
            {
                if (prod.WPF_Product_Name == productWPF.WPF_Product_Name)
                {
                    isCan = false; break;
                }
            }
            e.CanExecute = isCan;
        }

        private void ExecuteAddProductFromPanelInBasket(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            productWPF.WPF_Product_CountInBasket = 1;
            vmBasket.BasketProducts.Add(productWPF);
            StartAnimation();
        }

        public void StartAnimation()
        {
            Point pBeginAnimation;
            Point pEndAnimation;
            if (App.Current.MainWindow.FindName("LayoutMainWindow") is Grid gridMainWindow)
            {
                if (App.Current.MainWindow.FindName("BtnBasket") is BasketButton btnBasket)
                {
                    DoubleAnimation stub = new DoubleAnimation(); 
                    stub.From = 0;
                    stub.To = 0.1;
                    stub.Duration = TimeSpan.FromSeconds(0.05);
                    var tr = new TranslateTransform();
                    stub.Completed += (_, _) =>
                    {
                        Canvas cnvs = new Canvas();
                        Image img = new Image();
                        img.Source = productImg.Source;
                        img.Width = this.productImg.ActualWidth;
                        img.Height = this.productImg.ActualHeight;
                        cnvs.Width = img.Width;
                        cnvs.Height = img.Width;
                        img.RenderTransformOrigin = new Point(0.5, 0.5);
                        cnvs.Children.Add(img);

                        cnvs.VerticalAlignment = VerticalAlignment.Top;
                        cnvs.HorizontalAlignment = HorizontalAlignment.Left;
                        gridMainWindow.Children.Add(cnvs);

                        pBeginAnimation = this.productImg.TranslatePoint(new Point(0, 0), App.Current.MainWindow);
                        pEndAnimation = btnBasket.BasketImg.TranslatePoint(new Point(0, 0), App.Current.MainWindow);
                        cnvs.RenderTransform = new TranslateTransform(pBeginAnimation.X, pBeginAnimation.Y);

                        DoubleAnimation w = new DoubleAnimation(); //width
                        DoubleAnimation h = new DoubleAnimation(); //height

                        DoubleAnimation x = new DoubleAnimation(); // x coord
                        DoubleAnimation y = new DoubleAnimation(); // y coord

                        DoubleAnimation xScale = new DoubleAnimation();
                        DoubleAnimation yScale = new DoubleAnimation();

                        x.From = pBeginAnimation.X;
                        x.To = pEndAnimation.X;
                        y.From = pBeginAnimation.Y;
                        y.To = pEndAnimation.Y;
                        double timeAnimation = 0.5;
                        x.Duration = TimeSpan.FromSeconds(timeAnimation);
                        y.Duration = TimeSpan.FromSeconds(timeAnimation);

                        w.From = productImg.ActualWidth;
                        w.To = btnBasket.BasketImg.ActualWidth;
                        h.From = productImg.ActualHeight;
                        h.To = btnBasket.BasketImg.ActualHeight;
                        w.Duration = TimeSpan.FromSeconds(timeAnimation);
                        h.Duration = TimeSpan.FromSeconds(timeAnimation);

                        xScale.From = 1;
                        xScale.To = 0.2;
                        yScale.From = 1;
                        yScale.To = 0.2;
                        xScale.Duration = TimeSpan.FromSeconds(timeAnimation);
                        yScale.Duration = TimeSpan.FromSeconds(timeAnimation);

                        w.Completed += (_, _) =>
                        {
                            var scale = new ScaleTransform();
                            img.RenderTransform = scale;
                            xScale.Completed += (_, _) =>
                            {
                                gridMainWindow.Children.Remove(cnvs);
                            };
                            scale.BeginAnimation(ScaleTransform.ScaleXProperty, xScale);
                            scale.BeginAnimation(ScaleTransform.ScaleYProperty, xScale);
                        };

                        img.BeginAnimation(WidthProperty, w);
                        img.BeginAnimation(HeightProperty, h);

                        var translateTransform = new TranslateTransform();
                        cnvs.RenderTransform = translateTransform;
                        translateTransform.BeginAnimation(TranslateTransform.XProperty, x);
                        translateTransform.BeginAnimation(TranslateTransform.YProperty, y);
                    };
                    tr.BeginAnimation(TranslateTransform.XProperty, stub);
                }
            }
        }
    }
}

using System.Windows.Controls;
using System.Windows.Input;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel.Commands
{
    public class CommandDeleteSelectedProductsFromBasketInBasket
    {
        static CommandDeleteSelectedProductsFromBasketInBasket()
        {
            DeleteSelectedProductsFromBasketInBasket = new RoutedCommand("DeleteSelectedProductsFromBasketInBasket", typeof(Button));
        }
        public static RoutedCommand DeleteSelectedProductsFromBasketInBasket { get; set; }
    }
}

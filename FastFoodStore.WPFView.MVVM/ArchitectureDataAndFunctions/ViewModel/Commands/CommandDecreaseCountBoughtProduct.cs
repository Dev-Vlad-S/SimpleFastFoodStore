using System.Windows.Controls;
using System.Windows.Input;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel.Commands
{
    public class CommandDecreaseCountBoughtProduct
    {
        static CommandDecreaseCountBoughtProduct()
        {
            DecreaseCountBoughtProduct = new RoutedCommand("DecreaseCountBoughtProduct", typeof(Button));
        }
        public static RoutedCommand DecreaseCountBoughtProduct { get; set; }
    }
}

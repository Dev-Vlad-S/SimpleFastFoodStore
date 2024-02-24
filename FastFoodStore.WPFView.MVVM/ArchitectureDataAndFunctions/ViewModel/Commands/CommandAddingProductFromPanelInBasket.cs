using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel.Commands
{
    class CommandAddingProductFromPanelInBasket
    {
        static CommandAddingProductFromPanelInBasket()
        {
            AddProductFromPanelInBasket = new RoutedCommand("AddProductFromPanelInBasket", typeof(Button));
        }
        public static RoutedCommand AddProductFromPanelInBasket { get; set; }
    }
}

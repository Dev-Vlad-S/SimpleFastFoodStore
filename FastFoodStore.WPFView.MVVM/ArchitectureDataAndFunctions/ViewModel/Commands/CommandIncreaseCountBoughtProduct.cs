using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel.Commands
{
    public class CommandIncreaseCountBoughtProduct
    {
        static CommandIncreaseCountBoughtProduct()
        {
            IncreaseCountBoughtProduct = new RoutedCommand("IncreaseCountBoughtProduct", typeof(Button));
        }
        public static RoutedCommand IncreaseCountBoughtProduct { get; set; }
    }
}

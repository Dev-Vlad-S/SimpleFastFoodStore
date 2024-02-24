
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel.Commands
{
    public class CommandStartRegistrationOrder
    {
        static CommandStartRegistrationOrder()
        {
            StartRegistrationOrder = new RoutedCommand("StartRegistrationOrder", typeof(Button));
        }
        public static RoutedCommand StartRegistrationOrder { get; set; }
    }
}

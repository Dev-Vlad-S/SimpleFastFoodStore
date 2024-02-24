using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel
{
    public class VMBaseModelNotifyUserControls : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

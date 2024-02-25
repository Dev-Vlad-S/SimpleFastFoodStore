using FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel.Commands;

namespace FastFoodStore.WPFView.MVVM.ArchitectureDataAndFunctions.ViewModel
{
    public class VMNavigation : VMBaseModelNotifyUserControls
    {
        private MainVM _mainVM;
        public CommandNavigation UsePizzaPanel { get; private set; }
        public CommandNavigation UseSaucesPanel { get; private set; }
        public CommandNavigation UseRollsPanel { get; private set; }
        public CommandNavigation UseSnacksPanel { get; private set; }
        public CommandNavigation UseBasketPanel { get; private set; }

        public VMNavigation(MainVM mainVM)
        {
            _mainVM = mainVM;

            UsePizzaPanel = new CommandNavigation(OnShowPizzaPanel);
            UseSaucesPanel = new CommandNavigation(OnShowSaucesPanel);
            UseRollsPanel = new CommandNavigation(OnShowRollsPanel);
            UseSnacksPanel = new CommandNavigation(OnShowSnacksPanel);
            UseBasketPanel = new CommandNavigation(OnShowBasketPanel);
            _mainVM.SelectedProductPanel = _mainVM.PizzaPanel;
        }

        private void OnShowPizzaPanel(object parametr) => _mainVM.SelectedProductPanel = _mainVM.PizzaPanel;
        private void OnShowSaucesPanel(object parametr) => _mainVM.SelectedProductPanel = _mainVM.SaucesPanel;
        private void OnShowRollsPanel(object parametr) =>_mainVM.SelectedProductPanel = _mainVM.RollsPanel;
        private void OnShowSnacksPanel(object parametr) => _mainVM.SelectedProductPanel = _mainVM.SnacksPanel;
        private void OnShowBasketPanel(object parametr)
        {
            if(_mainVM.VMBasket.BasketProducts.Count < 1)
            {
                _mainVM.BasketPanel.VisualContentBasket.Content = _mainVM.BasketPanel.EmptyBasketsPanelWithoutProducts;
                _mainVM.SelectedProductPanel = _mainVM.BasketPanel;
                
            }
            else
            {
                if(_mainVM.VMBasket.IsStatusProducts)
                {
                    _mainVM.SelectedProductPanel = _mainVM.BasketPanel;
                    _mainVM.BasketPanel.VisualContentBasket.Content = _mainVM.BasketPanel.BasketsPanelAfterPayment;
                }
                else
                {
                    _mainVM.SelectedProductPanel = _mainVM.BasketPanel;
                    _mainVM.BasketPanel.VisualContentBasket.Content = _mainVM.BasketPanel.BasketsPanelWithProducts;
                }
            }
        }
    }
}

using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradePlusAdmin.Core;
using TradePlusAdmin.Services;
using TradePlusAdmin.Views;

namespace TradePlusAdmin.ViewModels
{   
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private ClientViewModel clientViewModel;
        public ClientViewModel ClientViewModel
        {
            get => clientViewModel;
            set => SetProperty(ref clientViewModel, value);
        }
        private ManagerViewModel managerViewModel;
        public ManagerViewModel ManagerViewModel
        {
            get => managerViewModel;
            set => SetProperty(ref managerViewModel, value);
        }
        private ProductViewModel productViewModel;
        public ProductViewModel ProductViewModel
        {
            get => productViewModel;
            set => SetProperty(ref productViewModel, value);
        }
        private PurchasedBoxViewModel purchasedBoxViewModel;
        public PurchasedBoxViewModel PurchasedBoxViewModel
        {
            get => purchasedBoxViewModel;
            set => SetProperty(ref purchasedBoxViewModel, value);
        }
        
        public MainWindowViewModel()
        {
            ClientViewModel = new ClientViewModel();
            ManagerViewModel = new ManagerViewModel();
            ProductViewModel = new ProductViewModel();
            PurchasedBoxViewModel = new PurchasedBoxViewModel();
        }
        

    }
}

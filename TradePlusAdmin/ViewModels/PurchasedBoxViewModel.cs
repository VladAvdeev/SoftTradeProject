using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradePlusAdmin.Core;
using TradePlusAdmin.Helpers;
using TradePlusAdmin.Source;
using TradePlusAdmin.Source.DataBase;

namespace TradePlusAdmin.ViewModels
{
    public class PurchasedBoxViewModel : NotifyPropertyChanged
    {
        private readonly PurchasedRepository purchasedRepository = new PurchasedRepository();
        private ObservableCollection<Purchased_Box> purchased_Box;
        public ObservableCollection<Purchased_Box> Purchased_Box
        {
            get => purchased_Box;
            set => SetProperty(ref purchased_Box, value);
        }
        private Purchased_Box selectedPurchaseBox;
        public Purchased_Box SelectedPurchaseBox
        {
            get => selectedPurchaseBox;
            set 
            {
                SetProperty(ref selectedPurchaseBox, value);
                OrderId = SelectedPurchaseBox?.Order_Id;
                ClientId = SelectedPurchaseBox?.Client_Id;
                ProductId = SelectedPurchaseBox?.Product_Id;
                OrderTime = SelectedPurchaseBox?.Purchase_Time;
            } 
        }
        private int? orderId;
        public int? OrderId
        {
            get => orderId;
            set => SetProperty(ref orderId, value);
        }
        private int? clientId;
        public int? ClientId
        {
            get => clientId;
            set => SetProperty(ref clientId, value);
        }
        private int? productId;
        public int? ProductId
        {
            get => productId;
            set => SetProperty(ref productId, value);
        }
        private DateTime? orderTime;
        public DateTime? OrderTime
        {
            get => orderTime;
            set => SetProperty(ref orderTime, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }
        public PurchasedBoxViewModel()
        {
            RefreshCommand = new Command(Refresh);
            AddCommand = new Command(Add, () => SendCondition());
            DeleteCommand = new Command(Delete, () => SelectedPurchaseBox != null);
            ChangeCommand = new Command(Update, () => SendCondition());
        }
        private void Refresh()
        {
            Purchased_Box = new ObservableCollection<Purchased_Box>(purchasedRepository.FindAll());
        }
        private void Add()
        {
            Purchased_Box product = new Purchased_Box() { Order_Id = OrderId.Value, Client_Id = ClientId.Value, Product_Id = ProductId.Value, Purchase_Time = OrderTime};
            ResponseServer response = purchasedRepository.Add(product);
            NotificationHelper.Instance.ShowResponse(response);
            purchasedRepository.Add(product);
            Refresh();
        }
        private void Delete()
        {
            ResponseServer response = purchasedRepository.Remove(SelectedPurchaseBox.Order_Id);
            NotificationHelper.Instance.ShowResponse(response);
            SelectedPurchaseBox = null;
            Refresh();
        }
        private void Update()
        {
            Purchased_Box product = new Purchased_Box() { Order_Id = OrderId.Value, Client_Id = ClientId.Value, Product_Id = ProductId.Value, Purchase_Time = OrderTime };
            ResponseServer response = purchasedRepository.Update(product);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private bool SendCondition()
        {
            return SelectedPurchaseBox != null;
        }
    }
}

using CommonLibrary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TradePlusAdmin.Core;
using TradePlusAdmin.Helpers;
using TradePlusAdmin.Source;
using TradePlusAdmin.Source.DataBase;

namespace TradePlusAdmin.ViewModels
{
    public class ClientViewModel : NotifyPropertyChanged
    {
        private readonly ClientRepository clientRepository = new ClientRepository();
       
        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set => SetProperty(ref clients, value);
        }
        private Client selectedClient;
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                SetProperty(ref selectedClient, value);
                Id = SelectedClient?.Id;
                Name = SelectedClient?.Name;
                ManagerId = SelectedClient?.Manager_Id;
                ClientStatus = SelectedClient?.Client_Status;
                ClientType = SelectedClient?.Client_Type;
               
                SelectedManager = SelectedClient?.Manager;


            }
        }
        private int? id;
        public int? Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private int? manager_id;
        public int? ManagerId
        {
            get => manager_id;
            set => SetProperty(ref manager_id, value);
        }
        private int? client_status;
        public int? ClientStatus
        {
            get => client_status;
            set => SetProperty(ref client_status, value);
        }
        private int? client_type;
        public int? ClientType
        {
            get => client_type;
            set => SetProperty(ref client_type, value);
        }
        private Manager selectedManager;
        public Manager SelectedManager
        {
            get => selectedManager;
            set => SetProperty(ref selectedManager, value);
        }
        
        private ICollection<Purchased_Box> purchased_Boxes;
        public ICollection<Purchased_Box> Purchased_Boxes
        {
            get => purchased_Boxes;
            set => SetProperty(ref purchased_Boxes, value);
        }
        private Purchased_Box selectedPurchased_Box;
        public Purchased_Box SelectedPurchased_Box
        {
            get => selectedPurchased_Box;
            set => SetProperty(ref selectedPurchased_Box, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ClientViewModel()
        {
            RefreshCommand = new Command(Refresh);
            AddCommand = new Command(Add, () => SendCondition());
            DeleteCommand = new Command(Remove, () => SelectedClient != null);
        }
        private void Refresh()
        {
            Clients = new ObservableCollection<Client>(clientRepository.FindAll());
           
        }
        private void Add()
        {
            Client client = new Client() { Id = Id.Value, Name = Name, Manager_Id = ManagerId.Value, Client_Status = ClientStatus.Value, Client_Type = ClientType.Value};
            ResponseServer response = clientRepository.Add(client);
            NotificationHelper.Instance.ShowResponse(response);
            clientRepository.Add(client);
            Refresh();
        }
        private void Remove()
        {
            ResponseServer response = clientRepository.Remove(SelectedClient.Id);
            NotificationHelper.Instance.ShowResponse(response);
            SelectedClient = null;
            Refresh();
        }
        private bool SendCondition()
        {
            return SelectedClient != null && Name != null;
        }
         
    }
}

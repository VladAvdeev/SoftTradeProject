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
    public class ManagerViewModel : NotifyPropertyChanged, IPageViewModel
    {
        private readonly ManagerRepository managerRepository = new ManagerRepository();
        private ObservableCollection<Manager> managers;
        public ObservableCollection<Manager> Managers
        {
            get => managers;
            set => SetProperty(ref managers, value);
        }
        private Manager selectedManager;
        public Manager SelectedManager
        {
            get => selectedManager;
            set
            {
                SetProperty(ref selectedManager, value);
                Id = SelectedManager?.Id;
                Name = SelectedManager?.Name;
                ClientId = SelectedManager?.Client_Id;
                SelectedClient = SelectedManager?.Client;
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
        private int? client_id;
        public int? ClientId
        {
            get => client_id;
            set => SetProperty(ref client_id, value);
        }
        private Client selectedClient;
        public Client SelectedClient
        {
            get => selectedClient;
            set => SetProperty(ref selectedClient, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }
        public ManagerViewModel()
        {
            RefreshCommand = new Command(Refresh);
            AddCommand = new Command(Add, () => SendCondition());
            DeleteCommand = new Command(Delete, () => SelectedManager != null);
            ChangeCommand = new Command(Update, () => SendCondition());
            
        }
        private void Refresh()
        {
            Managers = new ObservableCollection<Manager>(managerRepository.FindAll());
        }
        private void Add()
        {
            Manager manager = new Manager() { Id = Id.Value, Name = Name, Client_Id = ClientId.Value };
            ResponseServer response = managerRepository.Add(manager);
            NotificationHelper.Instance.ShowResponse(response);
            managerRepository.Add(manager);
            Refresh();
        }
        private void Delete()
        {
            ResponseServer response = managerRepository.Remove(SelectedManager.Id);
            NotificationHelper.Instance.ShowResponse(response);
            SelectedManager = null;
            Refresh();
        }
        private void Update()
        {
            Manager manager = new Manager() { Id = Id.Value, Name = Name, Client_Id = ClientId.Value };
            ResponseServer response = managerRepository.Update(manager);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private bool SendCondition()
        {
            return SelectedManager != null && Name != null;
        }
    }
}

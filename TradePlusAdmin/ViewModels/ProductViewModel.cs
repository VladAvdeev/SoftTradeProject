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
    public class ProductViewModel : NotifyPropertyChanged
    {
        private readonly ProductRepository productRepository = new ProductRepository();
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                SetProperty(ref selectedProduct, value);
                Id = SelectedProduct?.Id;
                Name = SelectedProduct?.Name;
                Price = SelectedProduct?.Price;
                SubscribeType = SelectedProduct?.Subscribe_Type;
                Period = SelectedProduct?.Period;
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
        private double? price;
        public double? Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        private int? subscribeType;
        public int? SubscribeType
        {
            get => subscribeType;
            set => SetProperty(ref subscribeType, value);
        }
        private DateTime? period;
        public DateTime? Period
        {
            get => period;
            set => SetProperty(ref period, value);
        }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ChangeCommand { get; }


        public ProductViewModel()
        {
            RefreshCommand = new Command(Refresh);
            AddCommand = new Command(Add, () => SendCondition());
            DeleteCommand = new Command(Delete, () => SelectedProduct != null);
            ChangeCommand = new Command(Update, () => SendCondition());
        }
        private void Refresh()
        {
            Products = new ObservableCollection<Product>(productRepository.FindAll());
        }
        private void Add()
        {
            Product product = new Product() { Id = Id.Value, Name = Name, Price = Price.Value, Subscribe_Type = SubscribeType.Value, Period = Period.Value };
            ResponseServer response = productRepository.Add(product);
            NotificationHelper.Instance.ShowResponse(response);
            productRepository.Add(product);
            Refresh();
        }
        private void Delete()
        {
            ResponseServer response = productRepository.Remove(SelectedProduct.Id);
            NotificationHelper.Instance.ShowResponse(response);
            SelectedProduct = null;
            Refresh();
        }
        private void Update()
        {
            Product product = new Product() { Id = Id.Value, Name = Name, Price = Price.Value, Subscribe_Type = SubscribeType.Value, Period = Period.Value };
            ResponseServer response = productRepository.Update(product);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private bool SendCondition()
        {
            return SelectedProduct != null && Name != null;
        }
    }
}

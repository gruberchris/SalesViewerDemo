using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace SalesViewerDemo.Models
{
    public class SalesOrderModel : BindableBase
    {
        private string _salesOrderNumber;

        private ObservableCollection<OrderItemModel> _orderItems;

        private int _totalOrderItems;

        private decimal _totalPrice;

        private decimal _totalMargin;

        private decimal _totalCost;

        public SalesOrderModel()
        {
            _orderItems = new ObservableCollection<OrderItemModel>();
            _orderItems.CollectionChanged += OrderItems_CollectionChanged;
        }

        private void OrderItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CalculateSalesOrderSums();
        }

        private void CalculateSalesOrderSums()
        {
            TotalOrderItems = _orderItems.Count;
            TotalPrice = _orderItems.Sum(i => i.Price);
            TotalCost = _orderItems.Sum(i => i.Cost);
            TotalMargin = _orderItems.Sum(i => i.Price - i.Cost);
        }

        public string SalesOrderNumber
        {
            get { return _salesOrderNumber; }
            set { SetProperty(ref _salesOrderNumber, value); }
        }

        public ObservableCollection<OrderItemModel> OrderItems
        {
            get { return _orderItems; }
            set
            {
                if (!_orderItems.Equals(value))
                {
                    // First, unsubscribe events
                    _orderItems.ToList().ForEach(i => i.PropertyChanged -= I_PropertyChanged);
                    // Assign new collection
                    _orderItems = value;
                    // Subscribe new objects to event handler
                    _orderItems.ToList().ForEach(i => i.PropertyChanged += I_PropertyChanged);
                    // Manually initiate new calculation
                    OrderItems_CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }

        private void I_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CalculateSalesOrderSums();
        }

        public int TotalOrderItems
        {
            get { return _totalOrderItems; }
            private set { SetProperty(ref _totalOrderItems, value); }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            private set { SetProperty(ref _totalPrice, value); }
        }

        public decimal TotalMargin
        {
            get { return _totalMargin; }
            private set { SetProperty(ref _totalMargin, value); }
        }

        public decimal TotalCost
        {
            get { return _totalCost; }
            private set { SetProperty(ref _totalCost, value); }
        }
    }
}

using Prism.Mvvm;
using SalesViewerDemo.Models;
using SalesViewerDemo.Services.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace SalesViewerDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly ISalesOrderService _salesOrderService;

        public MainWindowViewModel()
        {
            _salesOrderService = new SalesOrderService();
            LoadSalesOrders(500, 1000, true);
        }

        public void LoadSalesOrders(int howManySalesOrders, int howManySalesOrderItems, bool bulkLoadPerformance)
        {
            var tempSalesOrderModels = new ObservableCollection<SalesOrderModel>();
            var tempSelectableSalesOrders = new List<string>();
            var salesOrders = _salesOrderService.GetSalesOrders(howManySalesOrders, howManySalesOrderItems);

            // Transform from enterprise domain models to models for this app
            salesOrders.ToList().ForEach(s =>
            {
                var salesOrderModel = new SalesOrderModel
                {
                    SalesOrderNumber = s.SalesOrderNumber
                };

                var orderItemModels = s.OrderItems.ToList().Select(i => new OrderItemModel
                {
                    Cost = i.Cost,
                    ItemDescription = i.ItemDescription,
                    ItemNumber = i.ItemNumber,
                    Price = i.Price,
                    Quantity = i.Quantity
                });

                if(bulkLoadPerformance)
                {
                    // This method of bulk loading is magnitudes more performant as events are greatly reduced
                    salesOrderModel.OrderItems = new ObservableCollection<OrderItemModel>(orderItemModels);
                }
                else
                {
                    // This is essentially a brute force method of loading data. It will take magnitudes of
                    // more time as it generates events for each object added to the collection
                    orderItemModels.ToList().ForEach(i => salesOrderModel.OrderItems.Add(i));
                }
                

                tempSalesOrderModels.Add(salesOrderModel);
                tempSelectableSalesOrders.Add(s.SalesOrderNumber);
            });

            // Set view model's bindable properties with sales order data
            SalesOrders = new ListCollectionView(tempSalesOrderModels);
            SelectableSalesOrders = new ReadOnlyCollection<string>(tempSelectableSalesOrders);
        }

        public ICollectionView SalesOrders { get; private set; }

        public IReadOnlyCollection<string> SelectableSalesOrders { get; private set; }
    }
}

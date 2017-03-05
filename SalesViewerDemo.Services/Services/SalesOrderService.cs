using SalesViewerDemo.Services.Models;
using System;
using System.Collections.Generic;

namespace SalesViewerDemo.Services.Services
{
    public interface ISalesOrderService
    {
        IEnumerable<SalesOrderModel> GetSalesOrders(int numberOfFakeSalesOrders, int numberOfFakeSalesOrderItems);
    }

    public class SalesOrderService : ISalesOrderService
    {
        private int _numberOfFakeSalesOrders;

        private int _numberOfFakeSalesOrderItems;

        private Random _randomGenerator;

        public IEnumerable<SalesOrderModel> GetSalesOrders(int numberOfFakeSalesOrders, int numberOfFakeSalesOrderItems)
        {
            _numberOfFakeSalesOrders = numberOfFakeSalesOrders;
            _numberOfFakeSalesOrderItems = numberOfFakeSalesOrderItems;

            int seed = (numberOfFakeSalesOrders + numberOfFakeSalesOrderItems) / DateTime.Now.Millisecond;

            _randomGenerator = new Random(seed);

            return GetSalesOrdersMock();
        }

        private IList<SalesOrderModel> GetSalesOrdersMock()
        {
            List<SalesOrderModel> salesOrderModelsMock = new List<SalesOrderModel>();

            for(int counter = 0; counter < _numberOfFakeSalesOrders; counter++)
            {
                var salesOrderMock = CreateSalesOrderModelsMock();

                salesOrderModelsMock.Add(salesOrderMock);
            }

            return salesOrderModelsMock;
        }

        private SalesOrderModel CreateSalesOrderModelsMock()
        {
            var random = _randomGenerator;

            string fakeSalesOrderNumber = "SO" + random.Next(1000, 9999).ToString();

            var fakeSalesOrder = new SalesOrderModel();
            fakeSalesOrder.SalesOrderNumber = fakeSalesOrderNumber;
            fakeSalesOrder.OrderItems = new List<OrderItemModel>();

            int howManyItems = random.Next(_numberOfFakeSalesOrderItems);

            for (int counter = 0; counter < howManyItems; counter++)
            {
                var fakeOrderItem = new OrderItemModel();
                fakeOrderItem.ItemNumber = "Item" + random.Next(1000, 9999).ToString();
                fakeOrderItem.Cost = Math.Round((decimal)(random.Next(1, 49) + random.NextDouble()), 2, MidpointRounding.AwayFromZero);
                fakeOrderItem.Price = Math.Round((decimal)(random.Next(50, 99) + random.NextDouble()), 2, MidpointRounding.AwayFromZero);
                fakeOrderItem.Quantity = random.Next(1, 99);
                fakeOrderItem.ItemDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean tempus, purus in placerat porttitor, ligula nisi faucibus ex, eu semper elit mauris non eros. Donec non eros gravida, posuere nunc at, rutrum dui. Nam convallis vestibulum mi, id pretium nulla. Vivamus aliquam, urna a bibendum efficitur, magna justo laoreet augue, sit amet ornare sapien dui et purus. In libero justo, mollis at ex ut, dictum eleifend velit. Praesent luctus sed metus vitae egestas. Vivamus id sapien sit amet orci dignissim tempor sit amet id sem. Cras consequat nec lacus ut finibus. Mauris eu suscipit massa, at dignissim metus.";
                fakeOrderItem.SalesOrderNumber = fakeSalesOrderNumber;

                fakeSalesOrder.OrderItems.Add(fakeOrderItem);
            }

            return fakeSalesOrder;
        }
    }
}

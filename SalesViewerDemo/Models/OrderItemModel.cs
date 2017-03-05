using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesViewerDemo.Models
{
    public class OrderItemModel : BindableBase
    {
        private string _itemNumber;

        private string _itemDescription;

        private int _quantity;

        private decimal _price;

        private decimal _cost;

        private decimal _margin;

        public string ItemNumber
        {
            get { return _itemNumber; }
            set { SetProperty(ref _itemNumber, value); }
        }

        public string ItemDescription
        {
            get { return _itemDescription; }
            set { SetProperty(ref _itemDescription, value); }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }

        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public decimal Cost
        {
            get { return _cost; }
            set { SetProperty(ref _cost, value); }
        }

        public decimal Margin
        {
            get { return _margin; }
            set { SetProperty(ref _margin, value); }
        }
    }
}

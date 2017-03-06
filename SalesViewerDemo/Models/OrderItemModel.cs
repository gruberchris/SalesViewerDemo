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
            set
            {
                if(SetProperty(ref _quantity, value))
                {
                    this.OnPropertyChanged("Subtotal");
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if(SetProperty(ref _price, value))
                {
                    this.OnPropertyChanged("Margin");
                    this.OnPropertyChanged("Subtotal");
                }
            }
        }

        public decimal Cost
        {
            get { return _cost; }
            set
            {
                if(SetProperty(ref _cost, value))
                {
                    this.OnPropertyChanged("Margin");
                }
            }
        }

        public decimal Margin { get { return Price - Cost; } }

        public decimal Subtotal { get { return Quantity * Price; } }
    }
}

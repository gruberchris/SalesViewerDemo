using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesViewerDemo.Services.Models
{
    public class OrderItemModel
    {
        public string ItemNumber { get; set; }

        public string ItemDescription { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Cost { get; set; }

        public string SalesOrderNumber { get; set; }
    }
}

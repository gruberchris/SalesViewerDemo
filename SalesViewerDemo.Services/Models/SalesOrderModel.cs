using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesViewerDemo.Services.Models
{
    public class SalesOrderModel
    {
        public string SalesOrderNumber { get; set; }

        public IList<OrderItemModel> OrderItems { get; set; }

        public override string ToString()
        {
            return SalesOrderNumber;
        }
    }
}

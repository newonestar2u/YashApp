using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Model.Model
{
    public class Order : BaseModel
    {
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderBy { get; set; }
        public string SalesBy { get; set; }
        public decimal Discount { get; set; }
        public string DiscountReason { get; set; }
        public bool Approved { get; set; }
        public decimal Balance { get; set; }
        public decimal Payment { get; set; }
        public string PaymentType { get; set; }
    }
}

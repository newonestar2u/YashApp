using System;
using System.Collections.Generic;
using SalesApp.Model.Attributes;

namespace SalesApp.Model.Model
{
    [Uri("Orders")]
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

        public List<OrderLine> OrderLines { get; set; }

        public Order()
        {
            OrderLines = new List<OrderLine>();
        }
    }
}

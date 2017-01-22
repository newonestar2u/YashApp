﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Model.Model
{
    public class OrderLine : BaseModel
    {
        public int OrderNumber { get; set; }
        public DateTime DeliveredOn { get; set; }
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public string DeliveredBy { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
    }
}
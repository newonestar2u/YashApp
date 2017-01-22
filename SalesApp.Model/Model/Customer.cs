﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Model.Model
{
    using Newtonsoft.Json;

    public class Customer : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }
        public decimal Balance { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public IList<string> ImageUrls
        {
            get { return imageUrls; }
            set
            {
                if (value != null)
                    imageUrls = value;
            }
        }

        private IList<string> imageUrls = new List<string>() { "SalesApp.Images.bf4.bf4cover.png" };
    }
}
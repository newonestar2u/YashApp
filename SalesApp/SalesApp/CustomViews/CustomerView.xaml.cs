using System;
using System.Linq;
using SalesApp.Model.Model;
using SalesApp.ViewModels;

namespace SalesApp.CustomViews
{
    public partial class CustomerView
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void ButtonWater_OnClicked(object sender, EventArgs e)
        {
            var model = (CustomerViewModel)this.BindingContext;

            if (App.Orders.Any(x => x.CustomerId == model.Customer.CustomerId))
            {
                var order = App.Orders.First(x => x.CustomerId == model.Customer.CustomerId);

                var orderline = new OrderLine
                {
                    Amount = 100,
                    DeliveredBy = "",
                    Product = "Water",
                    Quantity = 1,
                    OrderNumber = order.Id
                };
                order.OrderLines.Add(orderline);
            }
            else
            {
                var order = new Order { CustomerId = model.Customer.CustomerId, OrderBy = "System" };

                var orderline = new OrderLine
                {
                    Amount = 100,
                    DeliveredBy = "",
                    Product = "Water",
                    Quantity = 1,
                    OrderNumber = order.Id
                };
                order.OrderLines.Add(orderline);

                App.Orders.Add(order);
            }
        }

        private void ButtonNews_OnClicked(object sender, EventArgs e)
        {
            var model = (CustomerViewModel)this.BindingContext;

            if (App.Orders.Any(x => x.CustomerId == model.Customer.CustomerId))
            {
                var order = App.Orders.First(x => x.CustomerId == model.Customer.CustomerId);

                var orderline = new OrderLine
                {
                    Amount = 5,
                    DeliveredBy = "",
                    Product = "Paper",
                    Quantity = 1,
                    OrderNumber = order.Id
                };
                order.OrderLines.Add(orderline);
            }
            else
            {
                var order = new Order { CustomerId = model.Customer.CustomerId, OrderBy = "System" };

                var orderline = new OrderLine
                {
                    Amount = 6,
                    DeliveredBy = "",
                    Product = "paper",
                    Quantity = 1,
                    OrderNumber = order.Id
                };
                order.OrderLines.Add(orderline);

                App.Orders.Add(order);
            }
        }
    }
}

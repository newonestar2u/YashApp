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

                var orderLine = order.OrderLines.AsQueryable().FirstOrDefault(x => x.Product == "Water");

                if (orderLine != null)
                {
                    orderLine.Quantity += 1;
                }
                else
                {
                    var newOrderline = new OrderLine
                    {
                        Amount = 100,
                        DeliveredBy = "",
                        Product = "Water",
                        Quantity = 1,
                        OrderNumber = order.Id
                    };
                    order.OrderLines.Add(newOrderline);
                }
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

                var orderLine = order.OrderLines.AsQueryable().FirstOrDefault(x => x.Product == "Paper");

                if (orderLine != null)
                {
                    orderLine.Quantity += 1;
                }
                else
                {
                    var newOrderline = new OrderLine
                    {
                        Amount = 100,
                        DeliveredBy = "",
                        Product = "Paper",
                        Quantity = 1,
                        OrderNumber = order.Id
                    };
                    order.OrderLines.Add(newOrderline);
                }
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

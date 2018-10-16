using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    class Order
    {
        public Order()
        {

        }
        public DateTime orderTime = DateTime.Now;
        public Customer customer;
        public long OrderId
        {
            get;
            set;
        }
        public Order(string CustName,long CustId,long newOrderId)   //构造函数
        {
            customer = new Customer(CustName, CustId);
            OrderId = newOrderId;
        }
        public OrderDetails orderDetails=new OrderDetails();
        public void SetOrderDetails(OrderDetails neworderDetails)
        {
            orderDetails = neworderDetails;
        }
        public override string ToString()
        {
            string x = "--------------------------------------------------\n";
            x += $"OrderId:{OrderId}\n";
            x += $"{customer}\n";
            x += orderDetails;
            x += $"OrderTime: {orderTime}\n";
            x += "--------------------------------------------------\n\n";
            return x;
        }
    }
}

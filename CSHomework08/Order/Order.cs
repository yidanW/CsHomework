using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    public class Order
    {
        //是一个属性，不能忘记，否则在列表中无法显示
        public List<OrderDetails> details
        {
            get;
            set;
        }
        
        public Customer customer
        {
            get;
            set;
        }
        public long Tel
        {
            get;
            set;
        }
        public long OrderId
        {
            get;
            set;
        }
        public Order(long newOrderId,Customer newcustomer)   //构造函数
        {
            customer = newcustomer;
            OrderId = newOrderId;
            details = new List<OrderDetails>();
        }
        public Order()
        {
            OrderId = 0;
            customer = new Customer();//分配内存空间
            details = new List<OrderDetails>();
        }
        public double amount
        {
            set;
            get;
        }
        public void SetAmount()
        {
            foreach(OrderDetails od in details)
            {
                amount += od.goods.Price * od.quality;
            }
        }
        public void AddDetails(OrderDetails newdetails)
        {
            this.details.Add(newdetails);
            SetAmount();
        }
        public void DelDetails(OrderDetails newdetails)
        {
            details.Remove(newdetails);
            SetAmount();
        }
        public override string ToString()
        {
            string x = null;
            x += $"OrderId:{OrderId}\n";
            x += $"{customer}\n";
            foreach (OrderDetails od in details )
            {
                x += od;
                x += '\n';
            }
            x += '\n';
            return x;
        }
    }
}

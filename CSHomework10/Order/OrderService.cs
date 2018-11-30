using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace order
{
    public class OrderService
    {
        
        public Dictionary<long,Order> OrderDic=new Dictionary<long, Order>();
        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDb())
            {
                return db.Orders.Include("orderDetails").ToList<Order>();
            }
        }
        public void DelOrderException(Dictionary<long, Order> OrderList,int OrderId,int OrderListCount)
        {
            if (OrderId > OrderListCount|| OrderId<0)
                throw new Exception("错误！账单不存在\n");
            if (OrderList.Count == 0)
                throw new Exception("错误！OrderList为空！\n");
        }
        public void OrderNullException(Dictionary<long,Order> OrderList)
        {
            if (OrderList.Count == 0)
                throw new Exception("错误！没有订单！\n");
        }
        public void AddOrder(Order newOrder)
        {
            using (var db = new OrderDb())
            {
                Check(newOrder);
                db.Orders.Add(newOrder);
                db.SaveChanges();//保存更改
            }
        }
        
        public void Check(Order order)
        {
            string Id = order.OrderId.ToString();
            if (Id.Length != 11)
            {
                throw new Exception("订单号输入有误！请按照年月日+三位流水号输入");
            }
            else
            {
                int year, month, day;
                year =(int) (order.OrderId / 10000000);
                month = (int)(order.OrderId / 100000 % 100);
                day = (int)(order.OrderId / 1000 % 100);
                if (year > 2020 || year < 1 || month > 12 || month < 1 || day < 1 || day > 31)
                    throw new Exception("订单号输入有误！请按照年月日+三位流水号输入");
            }
            string tel = order.Tel.ToString();
            if (tel.Length != 11)
                throw new Exception("电话输入有误，请输入11位数字！");
        }

        public void Delete(Order thisorder)
        {
            using (var db = new OrderDb())
            {
                var order = db.Orders.Include("orderdetails").SingleOrDefault(o=>o==thisorder);
                db.OrderDetails.RemoveRange(order.details);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
        public List<Order> FindOrderByCustomerName(string customerName)
        {
            using (var db = new OrderDb())
            {
                return db.Orders.Include("orderDetails").Where(o => o.customer.Equals(customerName)).ToList<Order>();
            }
        }
        public List<Order> FindOrderByOrderId(int OrderId=0)
        {
            using (var db = new OrderDb())
            {
                return db.Orders.Include("orderDetails").Where(o => o.OrderId.Equals(OrderId)).ToList<Order>();
            }
        }
        public List<Order> FindOrderByGoodsName(string goodsName)
        {
            using (var db=new OrderDb())
            {
                return db.Orders.Include("orderDetails").Where(o => o.details.Equals(goodsName)).ToList<Order>();
            }
        }
        public override string ToString()
        {
            string x="";
            foreach (var order in OrderDic)
            {
                x += order;
            }
            return x;
        }
    }
}

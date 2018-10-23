using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

//第六次作业:
//1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；
//  添加一个Import方法可以从XML文件中载入订单。
//2、为OrderService类的各个Public方法，编写测试用例，使用合法和非法的输出数据进行测试。

namespace order
{
    public class OrderService
    {
        public void Export(string fileName,object obj)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
            FileStream fs = new FileStream(fileName, FileMode.Create);
            xmlser.Serialize(fs, obj);
            fs.Close();
        }
        public object Import(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
            FileStream fs = new FileStream(fileName, FileMode.Open);
            object obj;
            obj=xmlser.Deserialize(fs);
            fs.Close();
            return obj;
        }
        public List<Order> OrderList = new List<Order>();
        public void DelOrderException(List<Order> OrderList,int OrderId,int OrderListCount)
        {
            if (OrderId > OrderListCount|| OrderId<0)
                throw new Exception("错误！账单不存在\n");
            if (OrderList.Count == 0)
                throw new Exception("错误！OrderList为空！\n");
        }
        public void OrderNullException(List<Order> OrderList)
        {
            if (OrderList.Count == 0)
                throw new Exception("错误！没有订单！\n");
        }
        public void AddOrder(Order newOrder)
        {
            OrderList.Add(newOrder);
        }
        public void DelOrder(List<Order> OrderList, int OrderId)
        {
            try
            {
                DelOrderException( OrderList,OrderId, OrderList.Count);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            OrderList.Remove(OrderList[OrderId]);       //用Remove方法移除一个Order对象
        }
        public IEnumerable<Order> LinqFindOrderByCustomer(List<Order> OrderList,string customerName=null,long customerId=0)
        {
            try
            {
                OrderNullException(OrderList);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var CustomerOrder = from order in OrderList
                                    where order.customer.Id == customerId
                                    select order;
            CustomerOrder = from order in OrderList
                                    where order.customer.Name==customerName
                                    select order;
            //foreach(Order order in CustomerOrder)
            //{
            //    Console.WriteLine("顾客姓名为" + customerName + "的订单是\n"+order);
            //}
            //foreach (Order order in CustomerOrder)
            //{
            //    Console.WriteLine("顾客Id为" + customerId + "的订单是\n" + order);
            //}
            return CustomerOrder;
        }
        public IEnumerable<Order> LinqFindOrderByOrderId(List<Order> OrderList,int OrderId=0)
        {
            try
            {
                OrderNullException(OrderList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var IdOrder = from order in OrderList where order.OrderId == OrderId select order;
            return IdOrder;
        }
        public IEnumerable<Order> FindOrderByGoods(List<Order> OrderList, string goodsName=null)
        {
            try
            {
                OrderNullException(OrderList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //foreach(Order order in OrderList)
            //{
            //    foreach(SingleGoods singlegoods in order.orderDetails.SingleGoodsList)
            //    {
            //        if (singlegoods.goods.Name == goodsName)
            //            Console.WriteLine("包含" + goodsName + "的订单有\n" + order);
            //    }
            //}
            var GoodsOrder = from order in OrderList from singlegoods in order.orderDetails.SingleGoodsList
                             where singlegoods.goods.Name == goodsName select order;
            return GoodsOrder;
        }
        public override string ToString()
        {
            string x="";
            foreach (var order in OrderList)
            {
                x += order;
            }
            return x;
        }
    }
}

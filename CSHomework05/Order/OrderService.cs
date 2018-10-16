using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
写一个订单管理的控制台程序，能够实现添加订单、删除订单、
修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
提示：需要写Order（订单）、OrderDetails（订单明细），
OrderService（订单服务）几个类，订单数据可以保存在OrderService中一个List中。
*/

namespace order
{
    class MyException:ApplicationException
    {
        public MyException(string message):base(message)
        {
        }
    }
    class OrderService
    {
        public List<Order> OrderList = new List<Order>();
        public void DelOrderException(List<Order> OrderList,int OrderId,int OrderListCount)
        {
            if (OrderId > OrderListCount|| OrderId<0)
                throw new MyException("错误！账单不存在\n");
            if (OrderList.Count == 0)
                throw new MyException("错误！OrderList为空！\n");
        }
        public void OrderNullException(List<Order> OrderList)
        {
            if (OrderList.Count == 0)
                throw new MyException("错误！没有订单！\n");
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
        public void LinqFindOrderByCustomer(List<Order> OrderList,string customerName=null,long customerId=0)
        {
            try
            {
                OrderNullException(OrderList);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if(customerId!=0)
            {
                var CustomerOrder = from order in OrderList
                                    where order.customer.Id == customerId
                                    select order;
                foreach (Order order in CustomerOrder)
                {
                    Console.WriteLine("顾客Id为" + customerId + "的订单是\n" + order);
                }
            }
            if(customerName!=null)
            {
                var CustomerOrder = from order in OrderList
                                    where order.customer.Name==customerName
                                    select order;
                foreach(Order order in CustomerOrder)
                {
                    Console.WriteLine("顾客姓名为" + customerName + "的订单是\n"+order);
                }
            }
        }
        public void LinqFindOrderByOrderId(List<Order> OrderList,int OrderId=0)
        {
            try
            {
                OrderNullException(OrderList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (OrderId != 0)
            //foreach (Order order in OrderList)
            //{
            //    if(order.OrderId== OrderId)
            //        Console.WriteLine("OrderId为" + OrderId + "的订单是：\n" + order);
            //}

            {
                var IdOrder = from order in OrderList where order.OrderId == OrderId select order;
                foreach (Order order in IdOrder)
                    Console.WriteLine("OrderId为" + OrderId + "的订单是：\n" + order);
            }
        }
        public void FindOrderByGoods(List<Order> OrderList, string goodsName=null)
        {
            try
            {
                OrderNullException(OrderList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if(goodsName!=null)
            {
                foreach(Order order in OrderList)
                {
                    foreach(SingleGoods singlegoods in order.orderDetails.SingleGoodsList)
                    {
                        if (singlegoods.goods.Name == goodsName)
                            Console.WriteLine("包含" + goodsName + "的订单有\n" + order);
                    }
                }
                
            }
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

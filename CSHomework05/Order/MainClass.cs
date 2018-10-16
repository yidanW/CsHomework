using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/*
写一个订单管理的控制台程序，能够实现添加订单、删除订单、
修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
提示：需要写Order（订单）、OrderDetails（订单明细），
OrderService（订单服务）几个类，订单数据可以保存在OrderService中一个List中。

1、对上次作业的订单程序，使用LINQ语句，
（1）实现按照商品名称、客户等字段查询订单的功能;
（2） 查询订单金额大于1万元的订单。
2、第五章课后第15题（改进例5-31的画树程序）。
*/
namespace order
{
    class program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order("张三", 20180001, 100);
            Order order2 = new Order("李四", 20180002, 101);
            Order order3 = new Order("王五", 20180003, 102);
            Goods banana = new Goods("Banana", 01, 3.98);
            Goods apple = new Goods("Apple", 02, 5.98);
            Goods fish = new Goods("Fish", 03, 19.98);
            Goods rice = new Goods("Rice", 04, 2.98);
            OrderDetails details1 = new OrderDetails();
            OrderDetails details2 = new OrderDetails();
            OrderDetails details3 = new OrderDetails();
            details1.AddGoods(banana, 10);
            details1.AddGoods(apple, 5);
            details1.AddGoods(rice, 100);
            details1.setTotalPrice();
            details2.AddGoods(rice, 23);
            details2.AddGoods(banana, 3);
            details2.AddGoods(fish, 4);
            details2.setTotalPrice();
            details3.AddGoods(fish, 3000);
            details3.AddGoods(rice, 14);
            details3.setTotalPrice();
            order1.SetOrderDetails(details1);
            order2.SetOrderDetails(details2);
            order3.SetOrderDetails(details3);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            Console.WriteLine("目前的订单为：\n"+orderService);
            orderService.FindOrderByGoods(orderService.OrderList, "Rice");
            orderService.LinqFindOrderByOrderId(orderService.OrderList, 102);
            orderService.LinqFindOrderByCustomer(orderService.OrderList, "张三");

            //使用Linq查询订单金额大于一万的订单
            var bigOrder = from order in orderService.OrderList
                           where order.orderDetails.totalPrice > 10000 select order;
            foreach (Order order in bigOrder)
            {
                Console.WriteLine("订单金额大于一万的订单有：\n"+order);
            }
        }
    }
}
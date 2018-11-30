using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
/*我的手机  20:43:45
第十次作业（最后一次:)：

使用EF框架，将订单系统的OrderService中的增删改查方法，
改为对MySQL数据库的操作，并调整原来订单系统的Winform代码，使这些操作正常工作。

截止时间29号晚九点。

*/

namespace order
{
    class program
    {
        static void Main(string[] args)
        {
            //初始化
            OrderService orderService = new OrderService();
            Customer c1 = new Customer("张三", 01);
            Customer c2 = new Customer("李四", 02);
            Customer c3 = new Customer("王五", 03);

            Order order1 = new Order(20181115001, c1);
            Order order2 = new Order(20181115002, c2);
            Order order3 = new Order(20181115003, c3);

            Goods banana = new Goods("Banana", 01, 3.98);
            Goods apple = new Goods("Apple", 02, 5.98);
            Goods fish = new Goods("Fish", 03, 19.98);
            Goods rice = new Goods("Rice", 04, 2.98);

            OrderDetails od1 = new OrderDetails(banana, 1, 3);
            OrderDetails od2 = new OrderDetails(apple, 2, 4);
            OrderDetails od3 = new OrderDetails(fish, 3, 5);
            OrderDetails od4 = new OrderDetails(rice, 4, 2);
            OrderDetails od5 = new OrderDetails(banana, 5, 3);
            OrderDetails od6 = new OrderDetails(apple, 1, 3);

            order1.Tel = 12345678901;
            order2.Tel = 13925270098;
            order3.Tel = 15827597888;
            order1.AddDetails(od1);
            order1.AddDetails(od2);
            order1.AddDetails(od3);
            order2.AddDetails(od1);
            order2.AddDetails(od4);
            order3.AddDetails(od6);
            
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);

            List<Order> GoodsOrder = orderService.FindOrderByGoodsName("Apple");
            List<Order> IdOrder = orderService.FindOrderByOrderId(2);
            List<Order> CustomerOrder = orderService.FindOrderByCustomerName("张三");
            foreach (Order order in GoodsOrder)
            {
                Console.WriteLine("符合商品条件的订单为：" + order);
            }
            foreach (Order order in IdOrder)
            {
                Console.WriteLine("符合ID条件的订单为：" + order);
            }
            foreach (Order order in CustomerOrder)
            {
                Console.WriteLine("符合客户条件的订单为：" + order);
            }
        }
    }
}

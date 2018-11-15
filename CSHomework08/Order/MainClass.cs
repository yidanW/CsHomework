using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
/*
 第七次作业
为订单管理的程序添加一个WinForm的界面。
通过这个界面，调用OrderService的各个方法，
实现创建订单、删除订单、修改订单、查询订单等功能。
要求：
（1）WinForm的界面部分单独写一个项目，依赖于原来的项目。
（2）主窗口实现查询展示功能，以及放置各种功能按钮。新建/修改订单功能使用弹出窗口。
（3）尽量通过数据绑定来实现功能。 注：订单明细可以设置DataMember来绑定。
解释时间下周三21:00
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

            //将所有的订单序列转化为xml文件
            String xmlFileName = "order";
            orderService.Export(xmlFileName,order1);
            string xml = File.ReadAllText(xmlFileName+".xml");
            Console.WriteLine("\nxml文件如下：\n\n" + xml + "\n");

            //读xml
            Order od = orderService.Import(xmlFileName) as Order;
            Console.WriteLine("\n从xml载入订单数据如下：\n\n" + od);

            //xslt转化为html文档
            orderService.XslTransform("order");
        }
    }
}
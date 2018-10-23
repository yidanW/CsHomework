using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
namespace order
{
    class program
    {
        static void Main(string[] args)
        {
            //Order order1 = new Order("张三", 20180001, 100);
            //Order order2 = new Order("李四", 20180002, 101);
            //Order order3 = new Order("王五", 20180003, 102);
            //Goods banana = new Goods("Banana", 01, 3.98);
            //Goods apple = new Goods("Apple", 02, 5.98);
            //Goods fish = new Goods("Fish", 03, 19.98);
            //Goods rice = new Goods("Rice", 04, 2.98);
            //OrderDetails details1 = new OrderDetails();
            //OrderDetails details2 = new OrderDetails();
            //OrderDetails details3 = new OrderDetails();
            //details1.AddGoods(banana, 10);
            //details1.AddGoods(apple, 5);
            //details1.AddGoods(rice, 100);
            //details1.setTotalPrice();
            //details2.AddGoods(rice, 23);
            //details2.AddGoods(banana, 3);
            //details2.AddGoods(fish, 4);
            //details2.setTotalPrice();
            //details3.AddGoods(fish, 3000);
            //details3.AddGoods(rice, 14);
            //details3.setTotalPrice();
            //order1.SetOrderDetails(details1);
            //order2.SetOrderDetails(details2);
            //order3.SetOrderDetails(details3);
            //OrderService orderService = new OrderService();
            //orderService.AddOrder(order1);
            //orderService.AddOrder(order2);
            //orderService.AddOrder(order3);
            //IEnumerable<Order> GoodsOrder=orderService.FindOrderByGoods(orderService.OrderList, "Rice");
            //IEnumerable<Order> IdOrder = orderService.LinqFindOrderByOrderId(orderService.OrderList, 102);
            //IEnumerable<Order> CustomerOrder = orderService.LinqFindOrderByCustomer(orderService.OrderList, "张三");
            //foreach (Order order in GoodsOrder)
            //{
            //    Console.WriteLine("符合商品条件的订单为：" + order);
            //}
            //foreach (Order order in IdOrder)
            //{
            //    Console.WriteLine("符合ID条件的订单为：" + order);
            //}
            //foreach (Order order in CustomerOrder)
            //{
            //    Console.WriteLine("符合客户条件的订单为：" + order);
            //}

            ////使用Linq查询订单金额大于一万的订单
            //var bigOrder = from order in orderService.OrderList
            //               where order.orderDetails.totalPrice > 10000 select order;
            //foreach (Order order in bigOrder)
            //{
            //    Console.WriteLine("订单金额大于一万的订单有：\n"+order);
            //}

            ////将所有的订单序列转化为xml文件
            //String xmlFileName = "order.xml";
            //orderService.Export(xmlFileName, orderService);
            //string xml = File.ReadAllText(xmlFileName);
            //Console.WriteLine("\nxml文件如下：\n\n" + xml+"\n");

            //OrderService os = orderService.Import(xmlFileName) as OrderService;
            //Console.WriteLine("\n从xml载入订单数据如下：\n\n"+os);

            OrderService os = new OrderService();
            Order odTest = new Order("Jane", 01, 0);
            os.AddOrder(odTest);
            os.Export("Test.xml", os);
            string xml = File.ReadAllText("Test.xml");
            Console.WriteLine(xml);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using order;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


//为OrderService类的各个Public方法，编写测试用例，使用合法和非法的输出数据进行测试。
namespace UnitTestProject1
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void OrderServiceTest()
        {
            OrderService os = new OrderService();
            Assert.IsNotNull(os.OrderList);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            OrderService os = new OrderService();
            Order od = new Order();
            os.AddOrder(od);
            Assert.AreEqual(os.OrderList.Count, 1);
        }

        [TestMethod]
        public void DelOrderTest()
        {
            OrderService os = new OrderService();
            Order od1 = new Order();
            Order od2 = new Order();
            os.AddOrder(od1);
            os.AddOrder(od2);
            os.DelOrder(os.OrderList, 1);
            Assert.AreEqual(os.OrderList.Count, 1);
        }

        [TestMethod]
        public void LinqFindOrderByCustomerTest()
        {
            OrderService os = new OrderService();
            Order od1 = new Order("Jane", 01, 0);
            Order od2 = new Order("Jackson", 02, 1);
            os.AddOrder(od1);
            os.AddOrder(od2);
            IEnumerable<Order> CustomerOrder = os.LinqFindOrderByCustomer(os.OrderList, "Jane");
            foreach (Order order in CustomerOrder)
                Assert.AreEqual(order, od1);
        }
        
        [TestMethod]
        public void LinqFindOrderByOrderIdTest()
        {
            OrderService os = new OrderService();
            Order od1 = new Order("Jane", 01, 0);
            Order od2 = new Order("Jackson", 02, 1);
            os.AddOrder(od1);
            os.AddOrder(od2);
            IEnumerable<Order> IdOrder = os.LinqFindOrderByOrderId(os.OrderList,01);
            foreach (Order order in IdOrder)
                Assert.AreEqual(order, od2);
        }

        [TestMethod]
        public void FindOrderByGoodsTset()
        {
            OrderService os = new OrderService();
            Order od1 = new Order("Jane", 01, 0);
            Order od2 = new Order("Jackson", 02, 1);
            os.AddOrder(od1);
            os.AddOrder(od2);
            Goods rice = new Goods("Rice", 04, 2.98);
            OrderDetails details1 = new OrderDetails();
            details1.AddGoods(rice, 2);
            od2.SetOrderDetails(details1);
            IEnumerable<Order> IdOrder = os.FindOrderByGoods(os.OrderList, "rice");
            foreach (Order order in IdOrder)
                Assert.AreEqual(order, od2);
        }

        [TestMethod]
        public void ExportTest()
        {
            OrderService os = new OrderService();
            Order odTest = new Order("Jane", 01, 0);
            os.AddOrder(odTest);
            os.Export("Test.xml", os);
            string xml = File.ReadAllText("Test.xml");
            string s = "<?xml version=\"1.0\"?>\r\n<OrderService xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <OrderList>\r\n    <Order>\r\n      <customer>\r\n        <Name>Jane</Name>\r\n        <Id>1</Id>\r\n      </customer>\r\n      <orderDetails>\r\n        <SingleGoodsList />\r\n        <totalPrice>0</totalPrice>\r\n      </orderDetails>\r\n      <OrderId>0</OrderId>\r\n    </Order>\r\n  </OrderList>\r\n</OrderService>";
            Assert.AreEqual(xml, s);
        }
        [TestMethod]
        public void ImportTest()
        {
            OrderService os = new OrderService();
            Order odTest = new Order("Jane", 01, 0);
            os.AddOrder(odTest);
            //os.Export("Test.xml", os);
            OrderService os1 = os.Import("Test.xml") as OrderService;
            Assert.AreNotEqual(os,os1);
        }
    }
}

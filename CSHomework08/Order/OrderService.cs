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
        public void Export(string fileName, object obj)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Order));
            FileStream fs = new FileStream(fileName+".xml", FileMode.Create);
            xmlser.Serialize(fs, obj);
            fs.Close();
        }
        public object Import(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Order));
            FileStream fs = new FileStream(fileName+ ".xml", FileMode.Open);
            object obj;
            obj = xmlser.Deserialize(fs);
            fs.Close();
            return obj;
        }
        public void XslTransform(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName+".xml");

            XPathNavigator nav = doc.CreateNavigator();
            nav.MoveToRoot();
            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(fileName + ".xslt");

            FileStream fs = new FileStream(fileName+".html", FileMode.Create);
            XmlTextWriter writer = new XmlTextWriter(fs,null);
            xt.Transform(nav, null, writer);
            fs.Close();
            Console.WriteLine(xt);
        }
            
        public Dictionary<long,Order> OrderDic=new Dictionary<long, Order>();
        public List<Order> GetAllOrders()
        {
            return OrderDic.Values.ToList();
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
            
                Check(newOrder);
            OrderDic[newOrder.OrderId] = newOrder;
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
        public void DelOrder(Order order)
        {
            OrderDic.Remove(order.OrderId);       //用Remove方法移除一个Order对象
        }
        public List<Order> FindOrderByCustomerName(string customerName)
        {
            try
            {
                OrderNullException(OrderDic);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var CustomerOrder = from order in OrderDic.Values
                                where order.customer.Name==customerName
                                    select order;
            return CustomerOrder.ToList();
        }
        public List<Order> FindOrderByOrderId(int OrderId=0)
        {
            try
            {
                OrderNullException(OrderDic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var IdOrder = from order in OrderDic.Values where order.OrderId == OrderId select order;
            return IdOrder.ToList();
        }
        public List<Order> FindOrderByGoodsName(string goodsName)
        {
            try
            {
                OrderNullException(OrderDic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var GoodsOrder = OrderDic.Values.Where(order => order.details.Where(
                  d => d.goods.Name == goodsName).Count() > 0);
            return GoodsOrder.ToList();
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

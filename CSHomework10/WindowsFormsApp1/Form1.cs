using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using order;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
            init();
        }
        //按条件查询
        private void button1_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    int id = Int32.Parse(textBox1.Text);
                    orderSource1.DataSource = orderService.FindOrderByOrderId(id);
                    break;
                case 1:
                    string cusname = textBox1.Text;
                    orderSource1.DataSource = orderService.FindOrderByCustomerName(cusname);
                    break;
                case 2:
                    string goodsname = textBox1.Text;
                    orderSource1.DataSource = orderService.FindOrderByGoodsName(goodsname);
                    break;
                case 3:
                    orderSource1.DataSource = orderService.GetAllOrders();
                    break;
            }
        }
        //初始化
        public void init()
        {
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

            orderSource1.DataSource = orderService.GetAllOrders();
        }
        //删除订单
        //如果order储存在list中，删除时会出现索引没有值的错误
        //故应用dictionary储存
        private void button4_Click(object sender, EventArgs e)
        {
            Order order= (Order)orderSource1.Current;
            if(order!=null)
            {
                orderService.Delete(order);
                orderSource1.DataSource = orderService.GetAllOrders();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order neworder = new Order();
            Form2 form2 = new Form2(neworder);
            form2.ShowDialog();
            neworder = form2.GetResult();
            neworder.SetAmount();
            if(neworder!=null)
            {
                orderService.AddOrder(neworder);
                orderSource1.DataSource = orderService.GetAllOrders();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // Order order = (Order)orderSource1.Current;
           // orderService.Export(order.OrderId.ToString(), order);
        }
    }
}

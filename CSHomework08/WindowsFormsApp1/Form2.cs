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
    public partial class Form2 : Form
    {
        public Order result;
        
        public Form2(Order order)//传入参数
        {
            result = order;
            InitializeComponent();

            Customer c1 = new Customer("张三", 01);
            Customer c2 = new Customer("李四", 02);
            Customer c3 = new Customer("王五", 03);
            custumerBindingSource1.Add(c1);
            custumerBindingSource1.Add(c2);
            custumerBindingSource1.Add(c3);

            Goods banana = new Goods("Banana", 01, 3.98);
            Goods apple = new Goods("Apple", 02, 5.98);
            Goods fish = new Goods("Fish", 03, 19.98);
            Goods rice = new Goods("Rice", 04, 2.98);
            Goods egg = new Goods("Egg", 05, 3.98);
            GoodsbindingSource1.Add(banana);
            GoodsbindingSource1.Add(apple);
            GoodsbindingSource1.Add(egg);
            GoodsbindingSource1.Add(fish);
            GoodsbindingSource1.Add(rice);
            OrderBindingSource.DataSource = order;
        }
        public Order GetResult()//传回参数
        {
            return result;
        }
        //保存时
        private void button1_Click(object sender, EventArgs e)
        {
            result = (Order)OrderBindingSource.Current;//绑定数据
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //此语句解决了details没有出现空白行的问题，可以记住这个方法
            if(detailsBindingSource.DataSource==null)
            {
                detailsBindingSource.Add(new OrderDetails());
            }
            //当前details的goods 由combox多选
            ((OrderDetails)(detailsBindingSource.Current)).goods = (Goods)comboBox1.SelectedItem;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //如果当前选择的是第二列
            if (e.ColumnIndex == 1)
            {
                //获取矩阵
                Rectangle R = dataGridView1.GetCellDisplayRectangle(
                    dataGridView1.CurrentCell.ColumnIndex,
                    dataGridView1.CurrentCell.RowIndex,
                    false);
                //设置位置
                comboBox1.Location = new Point(dataGridView1.Location.X + R.X,
                    dataGridView1.Location.Y + R.Y);
                //设置大小
                comboBox1.Width = 250;
                comboBox1.Height = 50;
                comboBox1.Visible = true;
            }
            //如果当前选择的不是第二列
            else
                comboBox1.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Order)(OrderBindingSource.Current)).customer =
                (Customer)comboBox2.SelectedItem;
        }
    }
}

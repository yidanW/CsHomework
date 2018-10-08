using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace program
{
    class MyException : Exception
    {
        private string id;
        public MyException(string exception)
        {
            id = exception;
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
    class Order
    {
        private int ID;
        private string username;
        List<OrderDetails> details = new List<OrderDetails>();
        public Order(int ID, string username)
        { 
            this.ID = ID;
            this.username = username;
        }
        public void delDetail(string name)
        {
            try
            {
                bool judge = false;
                for (int i = details.Count - 1; i >= 0; i--)
                {
                    if (name == details[i].getName())
                    {
                        details.RemoveAt(i);
                        judge = true;
                    }
                }
                if (!judge)
                {
                    throw new MyException("Error!");
                }
            }
            catch (MyException e)
            {
                Console.Write(e.Id);
            }
        }
        public int getID()
        {
            return ID;
        }
        public string getUsername()
        {
            return username;
        }
    class OrderDetails
    {
        private string name;
        private int price;
        private int account;
        public OrderDetails(string name, int price, int account)
        {
            this.name = name;
            this.price = price;
            this.account = account;
        }
        public int getAccount()
        {
            return account;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setAccount(int account)
        {
            this.account = account;
        }
        public void setPrice(int price)
        {
            this.price = price;
        }
        public int getPrice()
        {
            return price;
        }
        public string getName()
        {
            return name;
        }
        public void showDetails()
        {
                Console.WriteLine($"Name:{name}\nPrice:{price}\nAccount:{account}");
        }
    }

    class OrderService
    {
        public List<Order> orders;
        public OrderService()
        {
            orders = new List<Order>();
        }
        public void addOrder(Order order)
        {
            orders.Add(order);
        }
        public void delOrder(int ID)
        {
            try
            {
                bool judge = false;
                for (int i = orders.Count - 1; i >= 0; i--)
                {
                    if (orders[i].getID() == ID)
                    {
                        orders.RemoveAt(i);
                        judge = true;
                        break;
                    }
                }
                if (!judge)
                {
                    throw new MyException("Error!");
                }
            }
            catch (MyException e)
            {

                Console.Write(e.Id);
            }
        }
        public void changeOrder(int ID, string name1, string name2, int account, int price)
        {
            try
            {
                bool judge = false;
                for (int i = orders.Count - 1; i >= 0; i--)
                {
                    if (orders[i].getID() == ID)
                    {
                        for (int j = 0; j < orders[i].details.Count - 1; j++)
                        {
                            if (orders[i].details[j].getName() == name1)
                            {
                                orders[i].details[j].setName(name2);
                                orders[i].details[j].setPrice(price);
                                orders[i].details[j].setAccount(account);
                                judge = true;
                            }
                        }
                    }
                }
                if (!judge)
                {
                    throw new MyException("Error!");
                }
            }
            catch (MyException e)
            {
                Console.Write(e.Id);
            }
        }
        public void checkOrder(int id)
        {
            bool judge = false;
            for (int i = 0; i < orders.Count - 1; i++)
            {
                if (orders[i].getID() == id)
                {
                    for (int j = 0; j < orders[i].details.Count - 1; j++)
                        Console.WriteLine("商品:" + orders[i].details[j].getName() + " 单价：" +
                            orders[i].details[j].getPrice() + " 数量:" + orders[i].details[j].getAccount());
                    judge = true;
                }
            }
            try
            {
                if (!judge)
                    throw new MyException("Error");
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Id);
            }
        }
        public void checkOrder(string username)
        {
            bool judge = false;
            for (int i = 0; i < orders.Count - 1; i++)
            {
                if (orders[i].getUsername() == username)
                {
                    for (int j = 0; j < orders[i].details.Count - 1; j++)
                        Console.WriteLine("商品:" + orders[i].details[j].getName() + " 单价：" +
                            orders[i].details[j].getPrice() + " 数量:" + orders[i].details[j].getAccount());
                    judge = true;
                }
            }
            try
            {
                if (!judge)
                    throw new MyException("Error！");
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Id);
            }
        }
        
    }
        class Program
        {
            static void Main(string[] args)
            {
                OrderService orderservice = new OrderService();
                for (int i = 0; i < 10; i++)
                {
                    Order order = new Order(i, "Person"+i.ToString());
                    for (int j = 0; j < 3; j++)
                    {
                        order.details.Add(new OrderDetails("Goods",  j, j));
                    }
                    orderservice.orders.Add(order);
                }
                orderservice.checkOrder("Person100");
                orderservice.changeOrder(1, "Person4", "Goods5", 8, 45);
                orderservice.checkOrder(50);
                orderservice.checkOrder(2);
                orderservice.checkOrder(90);
                orderservice.changeOrder(15, "Person1", "Goods1", 3, 2);
            }
        }
    }
}
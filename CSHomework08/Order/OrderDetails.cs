using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    public class OrderDetails
    {
        public Goods goods
        {
            get;
            set;
        }
        public long id
        {
            get;
            set;
        }
        public int quality
        {
            get;
            set;
        }
        public OrderDetails(Goods newgoods,long newid,int newq)
        {
            goods = newgoods;
            id = newid;
            quality = newq;
        }
        public OrderDetails()
        { }
        public override string ToString()
        {
            string x = null;
            x += $"goods:{goods.ToString()}\t";
            x += $"id:{id.ToString()}\t";
            x += $"quality:{quality.ToString()}\t";
            return x;
        }
    }
}

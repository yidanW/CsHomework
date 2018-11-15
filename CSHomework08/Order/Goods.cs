using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    public class Goods
    {
        public Goods(string goodsName,long goodsId,double goodsPrice)
        {
            Name = goodsName;
            Id = goodsId;
            Price = goodsPrice;
        }
        public Goods()
        {

        }
        public string Name
        {
            get;
            set;
        }
        public long Id
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        public override string ToString()
        {
            return $"Goods Name:{Name}  Id:{Id}  Price:{Price}";
        }
    }
}

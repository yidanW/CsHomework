using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    class SingleGoods
    {
        public Goods goods=new Goods();
        public int Quality
        {
            get;
            set;
        }
        public SingleGoods(Goods newGoods, int goodsQuality)
        {
            goods.Id = newGoods.Id;
            goods.Name = newGoods.Name;
            goods.Price = newGoods.Price;
            Quality = goodsQuality;
        }
        public override string ToString()
        {
            string x = "";
            x += goods;
            x += "   ";
            x += Quality;
            return x;
        }
    }
}

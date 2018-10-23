using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order
{
    public class OrderDetails
    {
        public List<SingleGoods> SingleGoodsList = new List<SingleGoods>();
        public void AddGoods(Goods goods,int goodsQuality)
        {
            SingleGoods sinGoods = new SingleGoods(goods, goodsQuality);
            SingleGoodsList.Add(sinGoods);
        }
        public OrderDetails() { }
        public double totalPrice
        {
            set;
            get;
        }
        public void setTotalPrice()
        {
            for(int i=0;i<SingleGoodsList.Count;i++)
            {
                totalPrice += SingleGoodsList[i].goods.Price* SingleGoodsList[i].Quality;
            }
        }
        public override string ToString()
        {
            string x = "SingleGoodsList:\n";
            x += "GoodsId    GoodsName    Price    Quality\n";
            for(int i=0;i< SingleGoodsList.Count;i++)
            {
                x += $"    {SingleGoodsList[i].goods.Id}        { SingleGoodsList[i].goods.Name}        { SingleGoodsList[i].goods.Price}        {SingleGoodsList[i].Quality }\n";
            }
            x += $"                      Total price: {totalPrice}\n";
            return x;
        }
    }
}

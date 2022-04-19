using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount
{
    public class DiscountCalculation
    {
        public int GetDiscount(int count, int cost)
        {
            int discount = cost/500;
            if(count>=3&&count<5&&cost>0)
            {
                discount += 5;
                return discount;
            }
            if (count >= 5 && count < 10 && cost > 0)
            {
                discount += 10;
                return discount;
            }
            if (count >= 10 &&  cost > 0)
            {
                discount += 15;
                return discount;
            }
            if(count<0)
            {
                return -1;
            }
            if (cost < 0)
            {
                return -1;
            }
            return -1;
        }
    }
}

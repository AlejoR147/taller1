using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerGame.Characters;
public interface IBuyer
{
    public int Price { get; set; }

    public void Buy(Seller seller)
    {
        if (seller.WoodCounts <= 0) return;

        seller.DiscountWood();
        seller.IncreaseCoin(Price);
    }

}
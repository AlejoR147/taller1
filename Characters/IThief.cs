using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerGame.Characters;
public interface IThief
{
    public int StealAmount { get; set; }
    public void Steal(Seller seller)
    {
        if (seller.WoodCounts <= 0) return;
        seller.DiscountWood(StealAmount);
    }

}
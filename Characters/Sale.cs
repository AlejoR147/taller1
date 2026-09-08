using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerGame.Characters;
public class Sale : Transaction
{
    public Sale(string nameNpc, int totalCounts) : base(nameNpc,totalCounts)
    {
    }
}


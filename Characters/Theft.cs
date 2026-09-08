using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerGame.Characters;
public class Theft : Transaction
{
    public Theft(string nameNpc, int totalCounts) : base(nameNpc, totalCounts)
    {
    }
}


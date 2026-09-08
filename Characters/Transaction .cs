using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerGame.Characters
{
}
public class Transaction //historial
{
    public string NameNpc { get; set; }
    public int TotalCounts { get; set; }

    public Transaction(string nameNpc, int totalCounts)
    { 
      NameNpc = nameNpc;
      TotalCounts = totalCounts;
    }

}

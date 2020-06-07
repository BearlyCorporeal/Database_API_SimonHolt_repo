using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_API_SimonHolt.Models
{
    public class Product
    {
    public int PRODUCTID { get; set; }
    public string PRODNAME { get; set; }
    public decimal BUYPRICE { get; set; }
    public decimal SELLPRICE { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_API_SimonHolt.Models
{
    public class Purchase
    {
    int PRODUCTID { get; set; }
    string LOCATIONID { get; set; }
    DateTime DATETIMECREATED { get; set; }
    int QUANTITY { get; set; }
    decimal TOTAL { get; set; }
    }
}

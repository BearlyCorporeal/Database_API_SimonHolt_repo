using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_API_SimonHolt.Models
{
    public class orderinfo
    {
        public int ORDERID;
        public string SHIPPINGADDRESS;
        public string DATETIMECREATED;
        public string DATETIMEDISPATCHED;
        public decimal TOTAL;
        public int USERID;
        public int PRODUCTID;
        public int QUANTITY;
        public decimal DISCOUNT;
        public decimal SUBTOTAL;
    }
}

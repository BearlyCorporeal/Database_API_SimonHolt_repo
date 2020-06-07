using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Database_API_SimonHolt.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace Database_API_SimonHolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        dal db = new dal();
        // GET: api/order
        [HttpGet]
        public IEnumerable<order> Get()
        {
            try
            {
                //i changed the procedure because im not really sure what to do with a cursor in this context.
                DataTable dt = db.GetData("GET_OPEN_ORDERS", "<parameters></parameters>");
                var result = (from rw in dt.Select()
                              select new order
                              {

                                  ORDERID = Convert.ToInt32(rw["ORDERID"]),
                                  SHIPPINGADDRESS = Convert.ToString(rw["SHIPPINGADDRESS"]),
                                  DATETIMECREATED = Convert.ToString(rw["DATETIMECREATED"]),
                                  DATETIMEDISPATCHED = Convert.ToString(rw["DATETIMEDISPATCHED"]),
                                  TOTAL = Convert.ToDecimal(rw["TOTAL"]),
                                  USERID = Convert.ToInt32(rw["USERID"])
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/order/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<orderinfo> Get(int id)
        {
            try
            {
                //i also changed this procedure because i dont know what to do with cursors
                DataTable dt = db.GetData("GET_ ORDER_BY_ID", "<parameters>"+id+"</parameters>");
                var result = (from rw in dt.Select()
                              select new orderinfo
                              {

                                  ORDERID = Convert.ToInt32(rw["ORDERID"]),
                                  SHIPPINGADDRESS = Convert.ToString(rw["SHIPPINGADDRESS"]),
                                  DATETIMECREATED = Convert.ToString(rw["DATETIMECREATED"]),
                                  DATETIMEDISPATCHED = Convert.ToString(rw["DATETIMEDISPATCHED"]),
                                  TOTAL = Convert.ToDecimal(rw["TOTAL"]),
                                  USERID = Convert.ToInt32(rw["USERID"]),
                                  PRODUCTID = Convert.ToInt32(rw["PRODUCTID"]),
                                  QUANTITY = Convert.ToInt32(rw["QUANTITY"]),
                                  DISCOUNT = Convert.ToDecimal(rw["DISCOUNT"]),
                                  SUBTOTAL = Convert.ToDecimal(rw["DISCOUNT"]),
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/order
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string preParm = value;
            try
            {
                db.SetData("CREATE_ORDER", preParm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            string preParm = value;
            try
            {
                db.SetData("FULLFILL_ORDER", preParm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

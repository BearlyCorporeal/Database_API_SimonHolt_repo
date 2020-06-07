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
    public class ProductController : ControllerBase
    {
        dal db = new dal();
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            try
            {
                //i added a new Procedure to get the products
                DataTable dt = db.GetData("GET_ALL_PRODUCTS", "<parameters></parameters>");
                var result = (from rw in dt.Select()
                              select new Product
                              {
                                  PRODUCTID = Convert.ToInt32(rw["PRODUCTID"]),
                                  PRODNAME = Convert.ToString(rw["PRODNAME"]),
                                  BUYPRICE = Convert.ToDecimal(rw["BUYPRICE"]),
                                  SELLPRICE = Convert.ToDecimal(rw["SELLPRICE"])
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                DataTable dt = db.GetData("GET_PRODUCT_BY_ID", "<parameters><PRODUCTID>" + id + "</PRODUCTID></parameters>");
                var result = new Product
                {
                    PRODUCTID = Convert.ToInt32(dt.Rows[0]["PRODUCTID"]),
                    PRODNAME = Convert.ToString(dt.Rows[0]["PRODNAME"]),
                    BUYPRICE = Convert.ToDecimal(dt.Rows[0]["BUYPRICE"]),
                    SELLPRICE = Convert.ToDecimal(dt.Rows[0]["SELLPRICE"])
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string preParm = value;
            try
            {
                db.SetData("ADD_PRODUCT", preParm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

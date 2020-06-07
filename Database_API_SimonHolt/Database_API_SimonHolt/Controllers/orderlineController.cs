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
    public class orderlineController : ControllerBase
    {
        dal db = new dal();
        // GET: api/orderline
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/orderline/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/orderline
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string preParm = value;
            try
            {
                db.SetData("ADD_PPRODUCT_TO_ORDER", preParm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/orderline/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string preParm = "<parameters>" + id + "</parameters>";
            try
            {
                db.SetData("REMOVE_PRODUCT_FROM_ORDER", preParm);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

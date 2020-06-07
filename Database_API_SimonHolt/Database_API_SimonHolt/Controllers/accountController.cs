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
    public class accountController : ControllerBase
    {
        dal db = new dal();
        // GET: api/account
        [HttpGet]
        public IEnumerable<account> Get()
        {
            try
            {
                //i added a new Procedure to get the accounts
                DataTable dt = db.GetData("GET_ALL_ACCOUNTS", "<parameters></parameters>");
                var result = (from rw in dt.Select()
                              select new account
                              {

                                  ACCOUNTID = Convert.ToInt32(rw["ACCOUNTID"]),
                                  ACCTNAME = Convert.ToString(rw["ACCTNAME"]),
                                  BALANCE = Convert.ToDecimal(rw["BALANCE"]),
                                  CREDITLIMIT = Convert.ToDecimal(rw["CREDITLIMIT"])
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/account/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<accountinfo> Get(int id)
        {
            try
            {
                //i also changed this procedure because i dont know what to do with cursors
                DataTable dt = db.GetData("GET_ALL_ACCOUNTS", "<parameters></parameters>");
                var result = (from rw in dt.Select()
                              select new accountinfo
                              {

                                  ACCOUNTID = Convert.ToInt32(rw["ACCOUNTID"]),
                                  ACCTNAME = Convert.ToString(rw["ACCTNAME"]),
                                  BALANCE = Convert.ToDecimal(rw["BALANCE"]),
                                  CREDITLIMIT = Convert.ToDecimal(rw["CREDITLIMIT"]),
                                  USERID = Convert.ToInt32(rw["USERID"]),
                                  FIRSTNAME = Convert.ToString(rw["FIRSTNAME"]),
                                  SURNAME = Convert.ToString(rw["SURNAME"]),
                                  EMAIL = Convert.ToString(rw["EMAIL"])
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/account
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string preParm = value;
            try
            {
                db.SetData("ADD_CLIENT_ACCOUNT", preParm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/account/5
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

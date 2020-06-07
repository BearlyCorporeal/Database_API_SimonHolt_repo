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
    public class LocationController : ControllerBase
    {
        dal db = new dal();
        // GET: api/Location
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            try
            {
                //i added a new Procedure to get the locations
                DataTable dt = db.GetData("GET_ALL_LOCATIONS", "<parameters></parameters>");
                var result = (from rw in dt.Select()
                              select new Location
                              {
                                  LOCATIONID = Convert.ToString(rw["LOCATIONID"]),
                                  LOCNAME = Convert.ToString(rw["LOCNAME"]),
                                  ADDRESS = Convert.ToString(rw["ADDRESS"]),
                                  MANAGER = Convert.ToString(rw["MANAGER"])
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Location/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Location> Get(string id)
        {
            try
            {
                DataTable dt = db.GetData("GET_LOCATION_BY_ID", "<parameters><LOCATIONID>" + id + "</LOCATIONID></parameters>");
                var result = new Location
                {
                    LOCATIONID = Convert.ToString(dt.Rows[0]["LOCATIONID"]),
                    LOCNAME = Convert.ToString(dt.Rows[0]["LOCNAME"]),
                    ADDRESS = Convert.ToString(dt.Rows[0]["ADDRESS"]),
                    MANAGER = Convert.ToString(dt.Rows[0]["MANAGER"])
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Location
        [HttpPost]
        public void Post([FromBody] string value)
        {
            string preParm = value;
            try
            {
                db.SetData("ADD_LOCATION", preParm);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Location/5
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

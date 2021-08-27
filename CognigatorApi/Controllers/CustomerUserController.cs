using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CognigatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerUserController : ControllerBase
    {
        //[Produces("application/json")]
        [HttpGet, Route("GetCustomer/{clientId?}")]
        public IActionResult GetCustomer(string clientId)
        {
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\ClientUserInfo.json";
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
             
                var result = string.Empty;
                if (!string.IsNullOrEmpty(clientId))
                {
                    List<ClientUserInfo> CognigatorObject = JsonConvert.DeserializeObject<List<ClientUserInfo>>(json).Where(x => x.s_client_id == clientId).ToList();
                    result = JsonConvert.SerializeObject(CognigatorObject, Formatting.Indented);


                }
                else
                {
                    result = json;
                }
                //if (!result.Any())
                //{
                //    return NotFound("No Records Found");
                //}
                return Ok(result);
            }
        }

        public class ClientUserInfo
        {
            public string s_client_id { get; set; }
            public string s_client_name { get; set; }
            public string s_user_location { get; set; }
            public string s_user_latitude { get; set; }
            public string s_user_longtitude { get; set; }
            public string s_user_mobile_no { get; set; }
            public string s_client_email { get; set; }


        }
    }
}

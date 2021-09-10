using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace CognigatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        [HttpGet, Route("GetSR")]
        public IActionResult GetSR(string srId)
        {
            //LoadJson();
            //return new string[] { "values 1", "values 2" };
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\ServiceRequest.json";
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                #region
                //var JsonResult;
                //dynamic array = JsonConvert.DeserializeObject(json);
                //var items = new List<ServiceRequest>();
                //foreach (var item in array)
                //{
                //    Console.WriteLine(item);
                //    items.Add(new ServiceRequest()
                //    {
                //        sr_id = item.sr_id,
                //        n_category_id = item.n_category_id,
                //        n_subcategory_id = item.n_subcategory_id,
                //        sp_mapping_id = item.sp_mapping_id,
                //        sr_status_tran_id = item.sr_status_tran_id,
                //        s_client_id = item.s_client_id,
                //        d_created_date = item.d_created_date,
                //        s_created_by = item.s_created_by,
                //        s_active = item.s_active,
                //        misc_cost = item.misc_cost
                //    });
                //}
                //List<ServiceRequest> ServiceRequestResult = JsonConvert.DeserializeObject<List<ServiceRequest>>(json);
                #endregion
                var result =string.Empty;
                if (!string.IsNullOrEmpty(srId))
                {
                    List<ServiceRequest> ServiceRequestResult = JsonConvert.DeserializeObject<List<ServiceRequest>>(json).Where(x=> x.sr_id == srId).ToList();
                     result = JsonConvert.SerializeObject(ServiceRequestResult, Formatting.Indented);


                }
                else {
                    result = JsonConvert.SerializeObject(json, Formatting.Indented);
                }
                //if (!result.Any())
                //{
                //    return NotFound("No Records Found");
                //}
                return Ok(result);
            }
        }
        [HttpGet, Route("GetSRQueue/user")]
        public IActionResult GetSRQueue(string Client)
        {
            //LoadJson();
            //return new string[] { "values 1", "values 2" };
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\ServiceRequest.json";
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
          
                var result = string.Empty;
                if (!string.IsNullOrEmpty(Client))
                {
                    List<ServiceRequest> ServiceRequestResult = JsonConvert.DeserializeObject<List<ServiceRequest>>(json).Where(x => x.s_created_by == Client).OrderBy(s => s.n_priority).OrderByDescending(s => s.s_active).ToList();
                    result = JsonConvert.SerializeObject(ServiceRequestResult, Formatting.Indented);


                }
                else
                {
                    List<ServiceRequest> ServiceRequestResult = JsonConvert.DeserializeObject<List<ServiceRequest>>(json).OrderBy(s => s.n_priority).OrderByDescending(s => s.s_active).ToList();
                    result = JsonConvert.SerializeObject(ServiceRequestResult, Formatting.Indented);
                }
                //if (!result.Any())
                //{
                //    return NotFound("No Records Found");
                //}
                return Ok(result);
            }
        }
        public class ServiceRequest
        {
            public string sr_id { get; set; }
            public string n_category_id { get; set; }
            public string n_subcategory_id { get; set; }
            public string sp_mapping_id { get; set; }
            public string sr_status_tran_id { get; set; }
            public string s_client_id { get; set; }
            public string d_created_date { get; set; }
            public string s_created_by { get; set; }
            public string s_active { get; set; }
            public string misc_cost { get; set; }
            public int n_priority { get; set; }
            public string s_currency { get; set; }
            public string sp_name { get; set; }
            public string sp_id { get; set; }
            public string sp_rating { get; set; }
            public string s_category_name { get; set; }
            public string s_subcategory_name { get; set; }
            public DateTime time_in { get; set; }
            public DateTime? time_out { get; set; }


        }
    }
}

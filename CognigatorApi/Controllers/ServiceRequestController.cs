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
        [HttpGet]
        public IEnumerable<ServiceRequest> Get()
        {
            //LoadJson();
            //return new string[] { "values 1", "values 2" };
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\ServiceRequest.json";
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                var items = new List<ServiceRequest>();
                foreach (var item in array)
                {
                    Console.WriteLine(item);
                    items.Add(new ServiceRequest()
                    {
                        sr_id = item.sr_id,
                        n_category_id = item.n_category_id,
                        n_subcategory_id = item.n_subcategory_id,
                        sp_mapping_id = item.sp_mapping_id,
                        sr_status_tran_id = item.sr_status_tran_id,
                        s_client_id = item.s_client_id,
                        d_created_date = item.d_created_date,
                        s_created_by = item.s_created_by,
                        s_active = item.s_active,
                        misc_cost = item.misc_cost
                    });
                }
                List<ServiceRequest> ServiceRequestResult = JsonConvert.DeserializeObject<List<ServiceRequest>>(json);
                return (ServiceRequestResult);
            }
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "The value is" + id;
        }

        public void LoadJson()
        {
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\ServiceRequest.json";
            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine(item);
                   // Console.WriteLine("{0} {1}", item.SR_ID, item.N_CATEGORY_ID);
                }

                ////if (System.IO.File.Exists(jsonFilePath))
                ////{
                ////    JObject data = JObject.Parse(File.ReadAllText(jsonFilePath));
                ////}

               
                List<ServiceRequest> items = JsonConvert.DeserializeObject<List<ServiceRequest>>(json);
            }
            
        }

        public class ServiceRequest
        {
            public string sr_id;
            public string n_category_id;
            public string n_subcategory_id;
            public string sp_mapping_id;
            public string sr_status_tran_id;
            public string s_client_id;
            public string d_created_date;
            public string s_created_by;
            public string s_active;
            public string misc_cost;

        }
    }
}

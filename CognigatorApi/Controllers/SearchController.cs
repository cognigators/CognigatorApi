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
    public class SearchController : ControllerBase
    {
        [HttpGet, Route("GetCategorySP")]
        public IActionResult GetCategorySP(string category)
        {
            //LoadJson();
            //return new string[] { "values 1", "values 2" };
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\SpMaster.json";
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
                var result = string.Empty;
                if (!string.IsNullOrEmpty(category))
                {
                    //                    List<SpMaster> cognigatorObject = JsonConvert.DeserializeObject<List<SpMaster>>(json).Where(x => x.category_tagged.Split(',')
                    //.Where(category)).ToList();
                    //List<SpMaster> cognigatorObject = JsonConvert.DeserializeObject<List<SpMaster>>(json).Where(x => x.category_tagged.Split(',').Select(sValue => sValue.Trim()).Equals(category)).ToList();
                    List<SpMaster> cognigatorObject = JsonConvert.DeserializeObject<List<SpMaster>>(json).Where(x => x.category_tagged.ToLower().Contains(category.ToLower())).ToList();
                    result = JsonConvert.SerializeObject(cognigatorObject, Formatting.Indented);


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
        public class SpMaster
        {
            public string sp_master_id { get; set; }
            public string sp_name { get; set; }
            public string s_mobile_no { get; set; }
            public string s_email_id { get; set; }
            public string sp_location { get; set; }
            public string sp_latitude { get; set; }
            public string sp_longtitude { get; set; }
            public string is_sp_vacinated { get; set; }
            public string sp_vaccination_type_id { get; set; }
            public string no_of_vaccinations_done { get; set; }
            public string s_active { get; set; }
            public string d_from_date { get; set; }
            public string d__to_date { get; set; }
            public string s_created_by { get; set; }
            public string d_created_date { get; set; }
            public string category_tagged { get; set; }


        }
    }
}

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
    public class SubCategoriesController : ControllerBase
    {
        [HttpGet, Route("GetSubCategories/{SubCategoryId?}")]
        public IActionResult GetSubCategories(string SubCategoryId)
        {
            string jsonFilePath = @"..\\cognigatorApi\\JsonData\\SubCategoryMaster.json";
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
                if (!string.IsNullOrEmpty(SubCategoryId))
                {
                    List<SubCategoryMaster> CognigatorObject = JsonConvert.DeserializeObject<List<SubCategoryMaster>>(json).Where(x => x.n_subcategory_id == SubCategoryId).ToList();
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

        public class SubCategoryMaster
        {
            public string n_subcategory_id { get; set; }
            public string s_subcategory_name { get; set; }
            public string n_category_id { get; set; }
            public string s_category_name { get; set; }
            public string s_active { get; set; }
            public string d_from_date { get; set; }
            public string d_created_date { get; set; }
            public string s_created_by { get; set; }

        }
        
    }

}

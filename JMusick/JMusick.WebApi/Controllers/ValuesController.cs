using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMusick.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
        return new string[] {"value 1", "value 2"};
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get( int id)
        {
            return "value"+id;
        }

        //POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
           
        }

        //PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {

        }

        //DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}

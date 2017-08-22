using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;

namespace TagPay.Backoffice.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
		private ILogger<ValuesController> logger;

		public ValuesController(ILogger<ValuesController> logger)
		{
			this.logger = logger;
		}

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
			this.logger.LogWarning("kkkkk");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
			var bodyStr = "";

			Request.Body.Position = 0;

			using (StreamReader reader
					  = new StreamReader(Request.Body, Encoding.UTF8, true, 1024, true))
			{
				bodyStr = reader.ReadToEnd();
			}
			this.logger.LogWarning(bodyStr);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

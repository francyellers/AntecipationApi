using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntecipationApi.Models;
using AntecipationApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AntecipationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // GET api/values
        /*[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_transactionService.GetAll());
            // (new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }
        /*
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {            
        }
        */
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] long[] id)
        {
            //var t = JsonConvert.DeserializeObject<dynamic>(id[0].ToString());
            _transactionService.Update(id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntecipationApi.Models;
using AntecipationApi.Services;
using Microsoft.AspNetCore.Mvc;

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
        public string Post([FromBody] int[] id)
        {
            string x = "";
            for (int i = 0; i < id.Length; i++)
            {
                x = x + " - " + id[i] + " - " + id.Length;
            }
            return x;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoilerPlateCRUD.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountService _accService;
        public AccountController(IAccountService accService)
        {
            _accService = accService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            //var message = new HttpResponseMessage();
            //message.Content = _accService.GetAccounts();
            //message.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_accService.GetAccounts());
        }

        [HttpPost]
        public IActionResult AddAccount(Account acc)
        {
            if (_accService.InsertAccount(acc))
            {
                return Ok(true);
            }
            if(!_accService.InsertAccount(acc))
            {
                return Ok(false);
            }
            return NoContent();
        }

        //[HttpPut]
        //public List<Account> Get()
        //{
        //    return _accService.UpdateAccount();
        //}

        //[HttpDelete]
        //[ServiceFilter(typeof(IsAdminFilter))]
        //public HttpResponseMessage DisableAccount()
        //{

        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
    }
}

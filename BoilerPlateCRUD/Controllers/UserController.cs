using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoilerPlateCRUD.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IPersonalInfoService _personalInfoService;

        public UserController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }
        // GET: api/<controller>
        [Route("GetUserInfo")]
        [HttpGet]
        public IActionResult Get([FromBody]Guid? personalId)
        {
            Person user = _personalInfoService.GetPersonalInfo(personalId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Ok(false);
            }
        }

        [Route("UpdateUserInfo")]
        [HttpPut]
        public IActionResult Update([FromBody]Person person)
        {
            try
            {
                var personUpdated = _personalInfoService.UpdatePersonalInfo(person);
                if(personUpdated)
                {
                    return Ok(personUpdated);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"No user found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Update");
            }
        }

    }
}

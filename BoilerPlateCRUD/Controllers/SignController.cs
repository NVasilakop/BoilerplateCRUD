using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices;
using Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoilerPlateCRUD.Controllers
{
    [Route("api/[controller]")]
    public class SignController : Controller
    {
        private ISignOnService _signOnService;
        private ISignManager _signManager;
        public SignController(ISignOnService signOnService,ISignManager signManager)
        {
            _signOnService = signOnService;
            _signManager = signManager;
        }

        [Route("SignUp")]
        [HttpPost]
        public IActionResult Post([FromBody]SignOn signUp)
        {
           string signedUp = _signManager.SignUp(signUp);
            if(!string.IsNullOrWhiteSpace(signedUp))
            {
                return Ok(signedUp);
            }
            else
            {
                return Ok(false);
            }
        }

        [Route("SignIn")]
        [HttpPost]
        public IActionResult SignIs([FromBody]SignOn signIn)
        {
            Guid signedUp = _signOnService.SignIn(signIn);
            if (signedUp != default(Guid))
            {
                return Ok(signedUp);
            }
            else
            {
                return Ok(false);
            }
        }

    }
}

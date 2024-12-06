using Microsoft.AspNetCore.Mvc;
using NineDotsAssesment.API.Controllers;
using NineDotsAssesment.Core.Services.Interface;
using NineDotsAssesment.Shared.DTO;
using NineDotsAssesment.Shared.Models;

namespace NineDotsAssesment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerServices _srv;

        public CustomerController(ICustomerServices srv)
        {
            this._srv = srv;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerDTO InputData)
        {
            var response = await _srv.RegisterAccount(InputData);
            return GenerateResponse(response);
        }


        [HttpPost("VerifyPIN")]
        public async Task<IActionResult> VerifyPIN([FromBody] ConfirmPINModel confirmPINModel)
        {
            var response = await _srv.ConfirmPIN(confirmPINModel);
            return GenerateResponse(response);
        }

        [HttpPost("MigrateUser/{ic}")]
        public async Task<IActionResult> MigrateUser(string ic)
        {
            var response = await _srv.MigrateNewUser(ic);
            return GenerateResponse(response);
        }
    }
}

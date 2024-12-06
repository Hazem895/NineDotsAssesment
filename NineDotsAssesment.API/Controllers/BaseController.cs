using Microsoft.AspNetCore.Mvc;
using NineDotsAssesment.Shared.Models;
using System.Net;

namespace NineDotsAssesment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult GenerateResponse(ResponseModel response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return string.IsNullOrWhiteSpace(response.Response) ? Ok() : Ok(response.Response);
            }
            return string.IsNullOrWhiteSpace(response.Response) ? BadRequest() : BadRequest(response.Response);
        }
    }
}
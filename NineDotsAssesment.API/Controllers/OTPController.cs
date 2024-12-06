using Microsoft.AspNetCore.Mvc;
using NineDotsAssesment.Core.Services.Interface;
using NineDotsAssesment.Shared.Models;

namespace NineDotsAssesment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : BaseController
    {
        private readonly IOTPServices _otpSrv;

        public OTPController(IOTPServices otpSrv)
        {
            this._otpSrv = otpSrv;
        }

        [HttpPost("Mobile/Send/{id:guid}")]
        public async Task<IActionResult> SendMobileOTP(Guid id)
        {
            var result = await _otpSrv.SendMobileOTP(id);
            return GenerateResponse(result);
        }

        [HttpPost("Mobile/verify")]
        public async Task<IActionResult> VerifyMobileOTP([FromBody] VerifyOTPRequest verifyOTPRequest)
        {

            var result = await _otpSrv.VerifyMobileOTP(verifyOTPRequest);
            return GenerateResponse(result);
        }

        [HttpPost("Email/Send/{id:guid}")]
        public async Task<IActionResult> SendEmailOTP(Guid id)
        {
            var result = await _otpSrv.SendEmailOTP(id);
            return GenerateResponse(result);
        }

        [HttpPost("Email/Verify")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyOTPRequest verifyOTPRequest)
        {

            var result = await _otpSrv.VerifyEmailOTP(verifyOTPRequest);
            return GenerateResponse(result);
        }

    }
}

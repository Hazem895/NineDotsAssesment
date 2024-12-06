using NineDotsAssesment.Core.ExternalServices;
using NineDotsAssesment.Core.ExternalServices.Interface;
using NineDotsAssesment.Core.Services.Interface;
using NineDotsAssesment.Shared.Models;
using System.Net;

namespace NineDotsAssesment.Core.Services
{
    public class OTPServices : IOTPServices
    {
        private readonly IMobileOTPService _mobileOTPService;
        private readonly IEmailOTPService _emailOTPService;
        private readonly ICustomerServices _customerServices;

        public OTPServices(IMobileOTPService mobileOTPService, IEmailOTPService emailOTPService, ICustomerServices customerServices)
        {
            _mobileOTPService = mobileOTPService;
            _emailOTPService = emailOTPService;
            _customerServices = customerServices;
        }

        public async Task<ResponseModel> SendMobileOTP(Guid id)
        {
            var customerResponse = await _customerServices.GetCustomerById(id);
            var customer = customerResponse.Customer;
            var result = await _mobileOTPService.SendOTPAsync(customer.Mobile!);

            return new()
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.MethodNotAllowed
            };
        }

        public async Task<ResponseModel> VerifyMobileOTP(VerifyOTPRequest verifyOTPRequest)
        {
            var customerResponse = await _customerServices.GetCustomerById(verifyOTPRequest.Id);
            var customer = customerResponse.Customer;

            var result = await _mobileOTPService.VerifyOTPAsync(customer.Mobile!, verifyOTPRequest.OTP);

            return new()
            {
                StatusCode = (result.Success && result.IsValidOtp) ? HttpStatusCode.OK : HttpStatusCode.Unauthorized
            };
        }

        public async Task<ResponseModel> SendEmailOTP(Guid id)
        {
            var customerResponse = await _customerServices.GetCustomerById(id);
            var customer = customerResponse.Customer;
            var result = await _emailOTPService.SendOtpEmail(customer.Email!);
            return new()
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.MethodNotAllowed
            };
        }

        public async Task<ResponseModel> VerifyEmailOTP(VerifyOTPRequest verifyOTPRequest)
        {
            var customerResponse = await _customerServices.GetCustomerById(verifyOTPRequest.Id);
            var customer = customerResponse.Customer;

            var result = OtpManager.VerifyOtp(customer.Email!, verifyOTPRequest.OTP);

            return new()
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized
            };
        }

    }
}

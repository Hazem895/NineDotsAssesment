using NineDotsAssesment.Shared.Models;

namespace NineDotsAssesment.Core.Services.Interface
{
    public interface IOTPServices
    {
        Task<ResponseModel> SendMobileOTP(Guid id);
        Task<ResponseModel> VerifyMobileOTP(VerifyOTPRequest verifyOTPRequest);
        Task<ResponseModel> SendEmailOTP(Guid id);
        Task<ResponseModel> VerifyEmailOTP(VerifyOTPRequest verifyOTPRequest);
    }
}

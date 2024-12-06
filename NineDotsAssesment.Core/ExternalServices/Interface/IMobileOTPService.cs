using NineDotsAssesment.Shared.Models;

namespace NineDotsAssesment.Core.ExternalServices.Interface
{
    public interface IMobileOTPService
    {
        Task<bool> SendOTPAsync(string mobile);
        Task<VerifyOTPResponse> VerifyOTPAsync(string mobile, string otp);
    }
}

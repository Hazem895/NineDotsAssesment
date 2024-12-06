namespace NineDotsAssesment.Core.ExternalServices.Interface
{
    public interface IEmailOTPService
    {
        Task<bool> SendOtpEmail(string recipientEmail);
    }
}

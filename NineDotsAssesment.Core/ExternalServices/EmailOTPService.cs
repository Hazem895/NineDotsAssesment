using NineDotsAssesment.Core.ExternalServices.Interface;
using NineDotsAssesment.Shared.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NineDotsAssesment.Core.ExternalServices
{
    public class EmailOTPService : IEmailOTPService
    {
        private static string apiKey = "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";

        public async Task<bool> SendOtpEmail(string recipientEmail)
        {
            string otp = Helper.GenerateOTP();
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("domiti7760@confmin.com", "Example Sender User");
            var subject = "Verification email";
            var to = new EmailAddress(recipientEmail, "Example Guest User");
            var plainTextContent = $"Your OTP: {otp}";
            var htmlContent = $"<strong>Your OTP: {otp}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            Response response = await client.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                OtpManager.StoreOtp(recipientEmail, otp);
            }
            return response.IsSuccessStatusCode;
        }

    }
}
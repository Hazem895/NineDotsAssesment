using NineDotsAssesment.Core.ExternalServices.Interface;
using NineDotsAssesment.Shared.Helpers;
using NineDotsAssesment.Shared.Models;
using System.Text.Json;

namespace NineDotsAssesment.Core.ExternalServices
{
    public class MobileOTPService : IMobileOTPService
    {
        private static string textbeltApiUrl = "https://textbelt.com/text";
        private static string textbeltVerifyApiUrl = "https://textbelt.com/otp/verify?otp=$user_entered_otp&userid=$userid&key=$key";
        private static string apiKey = "aee7c9b74f83014e7d047f2b573b5d066c196a11FGcsfNdPIvOb3fMgDzzdepBPp";



        public async Task<bool> SendOTPAsync(string mobile)
        {
            try
            {
                string OTP = Helper.GenerateOTP();


                using HttpClient client = new();
                var content = new FormUrlEncodedContent(
                [
                    new KeyValuePair<string, string>("phone", mobile),
                    new KeyValuePair<string, string>("message", $"Your OTP code is: {OTP}"),
                    new KeyValuePair<string, string>("userid", $"{mobile}@verxtest.com"),
                    new KeyValuePair<string, string>("key", apiKey)
                ]);

                var response = await client.PostAsync(textbeltApiUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();

                var srvResponse = JsonSerializer.Deserialize<MobileOTPServiceResponse>(responseString);

                return srvResponse.Success;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<VerifyOTPResponse> VerifyOTPAsync(string mobile, string otp)
        {
            try
            {

                var client = new HttpClient();
                var verifyURL = textbeltVerifyApiUrl.Replace("$user_entered_otp", otp)
                                                    .Replace("$userid", $"{mobile}@verxtest.com")
                                                    .Replace("$key", apiKey);

                var request = new HttpRequestMessage(HttpMethod.Get, verifyURL);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                var srvResponse = JsonSerializer.Deserialize<VerifyOTPResponse>(responseString);

                return srvResponse;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
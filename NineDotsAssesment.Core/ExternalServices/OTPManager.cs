namespace NineDotsAssesment.Core.ExternalServices
{

    public static class OtpManager
    {
        // Dictionary to store OTPs with their expiration time
        private static Dictionary<string, (string otp, DateTime expiration)> otpStore = new Dictionary<string, (string otp, DateTime expiration)>();

        public static void StoreOtp(string email, string otp)
        {
            DateTime expirationTime = DateTime.Now.AddMinutes(10); // OTP expires in 10 minutes
            otpStore[email] = (otp, expirationTime);
        }

        public static bool VerifyOtp(string email, string enteredOtp)
        {
            if (otpStore.ContainsKey(email))
            {
                var otpEntry = otpStore[email];

                if (otpEntry.expiration > DateTime.Now && otpEntry.otp == enteredOtp)
                {
                    // OTP is valid
                    otpStore.Remove(email); // Optionally, remove the OTP after verification
                    return true;
                }
            }
            return false; // OTP is invalid or expired
        }
    }

}

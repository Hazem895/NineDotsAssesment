using FluentValidation;
using NineDotsAssesment.Shared.Models;
using System.Security.Cryptography;
using System.Text;

namespace NineDotsAssesment.Shared.Helpers
{
    public static class Helper
    {
        public static string HashPIN(string PIN)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(PIN));

            StringBuilder builder = new();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }

        public static bool VerifyPin(string enteredPin, string storedHashedPIN)
        {
            string enteredPinHash = HashPIN(enteredPin);

            return enteredPinHash.Equals(storedHashedPIN, StringComparison.OrdinalIgnoreCase);
        }

        public static string GenerateOTP()
        {
            Random random = new();
            string otp = random.Next(0, 9999).ToString("D4");
            return otp;
        }

        public static async Task<ValidationResponse> ValidateInput<T>(T entity, IValidator<T> _genericValidator)
        {
            var validationResult = await _genericValidator.ValidateAsync(entity);

            ValidationResponse validationResponse = new();

            if (!validationResult.IsValid)
            {
                validationResponse.IsValid = false;
                //log errors
                foreach (var failure in validationResult.Errors)
                {
                    //log("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

                    validationResponse.Errors.Add(new()
                    {
                        PropertyName = failure.PropertyName,
                        ErrorMessage = failure.ErrorMessage
                    });
                }
                return validationResponse;
            }
            validationResponse.IsValid = true;

            return validationResponse;
        }

    }

}

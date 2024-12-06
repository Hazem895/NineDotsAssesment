using FluentValidation;
using NineDotsAssesment.Shared.DTO;


namespace NineDotsAssesment.Core.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).NotNull();
            RuleFor(customer => customer.IC).NotNull();
            RuleFor(customer => customer.Mobile).NotNull();
            RuleFor(customer => customer.Email).NotNull().EmailAddress();
        }
    }
}

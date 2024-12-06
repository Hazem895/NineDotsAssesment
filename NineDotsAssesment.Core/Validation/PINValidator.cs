using FluentValidation;
using NineDotsAssesment.Shared.Models;

namespace NineDotsAssesment.Core.Validation
{
    public class PINValidator : AbstractValidator<ConfirmPINModel>
    {
        public PINValidator()
        {
            this.ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(customer => customer.Id).NotEmpty();
            RuleFor(customer => customer.PIN).NotEmpty().Length(6).Must(x => int.TryParse(x, out int i));
            RuleFor(customer => customer.ConfirmedPIN).Equal(customer => customer.PIN).WithMessage("Unmatched PIN");
        }
    }
}

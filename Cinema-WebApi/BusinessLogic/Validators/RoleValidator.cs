using BusinessLogic.DTOs;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class RoleValidator : AbstractValidator<RoleDTO>
    {
        public RoleValidator() 
        {
            RuleFor(tast => tast.Role)
                .NotEmpty()
                .NotNull();
        }
    }
}

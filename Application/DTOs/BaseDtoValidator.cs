using FluentValidation;

namespace Application.DTOs
{
    public class BaseDtoValidator : AbstractValidator<BaseDto>
    {
        public BaseDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("The entity has not identity number");

           
        }

    }
}

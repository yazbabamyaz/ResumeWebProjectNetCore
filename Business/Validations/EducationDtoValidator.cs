using Core.DTOs;
using FluentValidation;

namespace Service.Validations
{
    public class EducationDtoValidator : AbstractValidator<EducationDto>
    {
        public EducationDtoValidator()
        {

            RuleFor(x => x.SchoolName).NotEmpty().WithMessage("Boş Geçmeyin.").Length(3, 30).WithMessage("{PropertyName} Karakter sayısı 3-30 arası olmalıdır.");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} alanını boş geçmeyin");
            RuleFor(x => x.Date).NotEmpty().NotNull();
        }
    }
}

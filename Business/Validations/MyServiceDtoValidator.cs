using Core.DTOs;
using FluentValidation;

namespace Service.Validations
{
    public class MyServiceDtoValidator : AbstractValidator<MyServiceDto>
    {
        public MyServiceDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} gerekli bir alandır.");
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Boş Geçmeyin.").Length(3, 30).WithMessage("{PropertyName} Karakter sayısı 3-30 arası olmalıdır.");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} alanını boş geçmeyin");
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}

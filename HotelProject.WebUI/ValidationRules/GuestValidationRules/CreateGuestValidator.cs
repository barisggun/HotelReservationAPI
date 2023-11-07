using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı alanı boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("en az 3 karakter");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("en az 3 karakter");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("en az 20 karakter");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("en az 30 karakter");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("en az 20 karakter");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.UserProfile.Commands.AddProfile;

namespace WebUtil.Lyrics.Application.Validation.Profile.AddProfile
{
    public class AddProfileValidator: AbstractValidator<AddProfileCommand>
    {
        public AddProfileValidator() { 
            ValidateBirthDate();
        }

        private void ValidateBirthDate()
        {
            RuleFor(c => c.Birthdate).Cascade(CascadeMode.Stop)
                .NotEmpty().When(c => c.Birthdate != null)
                .Must(BeAValidDate)
                .WithMessage("Must be datetime type");
                
        }

   

        private  bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }


    }
}

using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Services.Commands.Register;

namespace WebUtil.Lyrics.Application.Validation.Authentication.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator() {
            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(user => user.Username)
                .NotEmpty()
                .MinimumLength(6);

        }
    }
}

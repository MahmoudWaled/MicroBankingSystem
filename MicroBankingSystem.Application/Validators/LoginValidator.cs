using FluentValidation;
using MicroBankingSystem.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.Application.Validators
{
    public class LoginValidator :AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}

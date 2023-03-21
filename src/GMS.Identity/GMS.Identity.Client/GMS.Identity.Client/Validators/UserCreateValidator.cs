using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GMS.Identity.Client.Models;

namespace GMS.Identity.Client.Validators;

public class UserCreateValidator:AbstractValidator<UserCreateApiModel>
{
    public UserCreateValidator()
    {
        RuleFor(u=>u.UserName).NotEmpty().WithMessage("Name mast not be empty!");
        RuleFor(u => u.UserName).MaximumLength(200).WithMessage("Name is too long!");
        RuleFor(u => u.UserName).Must(BeSomeCondition);
        RuleFor(u => u.Email).EmailAddress().WithMessage("Email addres is incoorect");
    }

    protected bool BeSomeCondition(string? s)
    {
        return true;
    }
}

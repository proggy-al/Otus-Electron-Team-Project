using Bogus;
using GMS.Identity.Client.Models;
using GMS.Identity.Client.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace GMS.Identity.Test.WebHost
{
    public class UserValidatorTests
    {
        private readonly UserCreateValidator _userCreateValidator;

        public UserValidatorTests()
        {
            _userCreateValidator = new UserCreateValidator();
        }

        public UserCreateApiModel CreateUserCreateApiModel(bool isMailCorrect = true, bool isPasswordValid = true)
        {
            var user = new Faker<UserCreateApiModel>()
                .RuleFor(u => u.UserName, f => f.Name.FirstName())
                .RuleFor(u => u.TelegramUserName, () => "@telegram")
                .RuleFor(u => u.Role, () => "User")
                .RuleFor(u => u.Email, () => isMailCorrect ? "test@mail.ru" : "xxxxx")
                .RuleFor(u => u.Password, () => isPasswordValid ? "123456" : "12345");

            return user.Generate();
        }

        [Fact]
        public void UserValidator_IncorrectMail_ShouldhaveError()
        {
            //Assign
            var model = CreateUserCreateApiModel(false);
            //Act
            var result = _userCreateValidator.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(person => person.Email);
        }

        [Fact]
        public void UserValidator_ShortPassword_ShouldhaveError()
        {
            //Assign
            var model = CreateUserCreateApiModel(true,false);
            //Act
            var result = _userCreateValidator.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(person => person.Password);
        }

    }
}

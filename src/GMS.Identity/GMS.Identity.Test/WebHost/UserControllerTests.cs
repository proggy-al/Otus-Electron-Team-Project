using AutoFixture;
using AutoFixture.AutoMoq;
using Bogus;
using FluentAssertions;
using GMS.Identity.Client.Models;
using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.WebHost.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Test.WebHost
{
    public class UserControllerAsyncTests:IDisposable
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserController _userController;

        public UserControllerAsyncTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _userRepositoryMock = fixture.Freeze<Mock<IUserRepository>>();
            _userController = fixture.Build<UserController>().OmitAutoProperties().Create();
        }

        public UserCreateApiModel CreateUserCreateApiModel(bool isMailCorrect=true, bool isPasswordValid=true)
        {
            var user =new Faker<UserCreateApiModel>()
                .RuleFor(u=>u.UserName,f=>f.Name.FirstName())
                .RuleFor(u=>u.TelegramUserName, ()=>"@telegram")
                .RuleFor(u=>u.Role,()=>"User")
                .RuleFor(u=>u.Email, ()=> isMailCorrect?"test@mail.ru":"xxxxx")
                .RuleFor(u=>u.Password,()=>isPasswordValid?"123456":"12345");

            return user.Generate();
        }

        public UserApiModel CreateUserApiModel(UserCreateApiModel User)
        {
            var user = new UserApiModel()
            {
                Email = User.Email,
                TelegramUserName = User.TelegramUserName,
                IsActive = true,
                Role = User.Role,
                UserName = User.UserName,
                Id = Guid.NewGuid()
            };

            return user;
        }


        [Fact]
        public async void CreateUserAsync_CreateUserCreateApiModel_ReturnsOK()
        {
            // Arrange
            var user = CreateUserCreateApiModel();
            var userReturn = CreateUserApiModel(user);

            _userRepositoryMock.Setup(repo => repo.CreateAsync(user)).ReturnsAsync(userReturn);

            // Act
            var result = await _userController.CreateUser(user);

            var res = (OkObjectResult)result.Result;

            // Assert
            res.Should().NotBeNull();
            res.Value.Should().BeEquivalentTo(userReturn);

        }

        //[Fact]
        //public async void CreateUserAsync_CreateUserCreateApiModelWithNotValidEmail_ReturnsBadRequest()
        //{
        //    // Arrange
        //    var user = CreateUserCreateApiModel(false,false);
        //    var userReturn = CreateUserApiModel(user);

        //    _userRepositoryMock.Setup(repo => repo.CreateAsync(user)).ReturnsAsync(userReturn);

        //    // Act
        //    var result = await _userController.CreateUser(user);

        //    var res = result.Result;

        //    // Assert
        //    // Assert
        //    res.Should().NotBeNull();
        //    res.Should().BeEquivalentTo(new BadRequestResult());

        //}

        public void Dispose()
        {
        }
    }
}

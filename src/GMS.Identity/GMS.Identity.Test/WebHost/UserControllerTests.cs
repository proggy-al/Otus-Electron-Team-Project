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
    public class UserControllerAsyncTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserController _userController;

        public UserControllerAsyncTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _userRepositoryMock = fixture.Freeze<Mock<IUserRepository>>();
            _userController = fixture.Build<UserController>().OmitAutoProperties().Create();
        }

        public UserCreateApiModel CreateUserCreateApiModel()
        {
            var user =new Faker<UserCreateApiModel>()
                .RuleFor(u=>u.UserName,f=>f.Name.FirstName())
                .RuleFor(u=>u.TelegramUserName, ()=>"@telegram")
                .RuleFor(u=>u.Role,()=>"User")
                .RuleFor(u=>u.Email, ()=>"test@mail.ru")
                .RuleFor(u=>u.Password,()=>"123456");

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
        public async void CreateUserAsync_PartnerIsNotFound_ReturnsOK()
        {
            // Arrange
            var user = CreateUserCreateApiModel();
            var userReturn = CreateUserApiModel(user);

            _userRepositoryMock.Setup(repo => repo.CreateAsync(user)).ReturnsAsync(userReturn);

            // Act
            var result = await _userController.CreateUser(user);

            // Assert
            result.Value.Should().NotBeEquivalentTo(userReturn);//NotBeNull();
        }

        
    }
}

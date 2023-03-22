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
            var user =new Faker<UserCreateApiModel>();

            return user.Generate();
        }

        public UserApiModel CreateUserApiModel()
        {
            return new Faker<UserApiModel>().Generate();
        }

        [Fact]
        public async void CreateUserAsync_PartnerIsNotFound_ReturnsOK()
        {
            // Arrange
            var user = CreateUserCreateApiModel();
            var userReturn = CreateUserApiModel();

            _userRepositoryMock.Setup(repo => repo.CreateAsync(user)).ReturnsAsync(userReturn);

            // Act
            var result = await _userController.CreateUser(user);

            // Assert
            result.Should().NotBeNull();
        }

        
    }
}

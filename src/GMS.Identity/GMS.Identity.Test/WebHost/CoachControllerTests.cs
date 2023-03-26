using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GMS.Identity.Client.Models;
using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.WebHost.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMS.Identity.DataAccess.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GMS.Identity.Test.WebHost
{
    public class CoachControllerTests
    {
        private readonly Mock<ICoachRepository> _coachRepositoryMock;
        private readonly CoachController _coachController;

        public CoachControllerTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _coachRepositoryMock = fixture.Freeze<Mock<ICoachRepository>>();
            _coachController = fixture.Build<CoachController>().OmitAutoProperties().Create();
        }

        public UserCreateApiModel CreateUserCreateApiModel()
        {
            var user = new Faker<UserCreateApiModel>()
                .RuleFor(u => u.UserName, f => f.Name.FirstName())
                .RuleFor(u => u.TelegramUserName, () => "@telegram")
                .RuleFor(u => u.Role, () => "Coach")
                .RuleFor(u => u.Email, () => "test@mail.ru")
                .RuleFor(u => u.Password, () => "123456");

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
        public async void GetCoachAsync_ById_ReturnCoach()
        {
            // Arrange
            var coach = CreateUserCreateApiModel();
            var coachReturn = CreateUserApiModel(coach);
            //var coachId=Guid.NewGuid();

            _coachRepositoryMock.Setup(repo => repo.GetCoach(coachReturn.Id)).ReturnsAsync(coachReturn);

            // Act
            var result = await _coachController.GetCoach(coachReturn.Id);

            var res = (OkObjectResult)result.Result;

            // Assert
            res.Should().NotBeNull();
            res.Value.Should().BeEquivalentTo(coachReturn);

        }

        [Fact]
        public async void GetCoachAsync_ByNotExistingId_ReturnNotFound()
        {
            // Arrange
            var coach = CreateUserCreateApiModel();
            var coachReturn = CreateUserApiModel(coach);
            var randomCoachId=Guid.NewGuid();

            _coachRepositoryMock.Setup(repo => repo.GetCoach(coachReturn.Id)).ReturnsAsync(coachReturn);

            // Act
            var result = await _coachController.GetCoach(randomCoachId);

            var res = result;

            // Assert
            res.Should().NotBeNull();
            res.Result.Should().BeEquivalentTo(new NotFoundResult());

        }
    }
}

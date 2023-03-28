using AutoFixture.AutoMoq;
using AutoFixture;
using AutoMapper;
using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.WebHost;
using GMS.Identity.WebHost.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMS.Identity.Client.Models;
using FluentAssertions;

namespace GMS.Identity.Test.WebHost
{
    public class AutoMapperTest : IClassFixture<TestFixture>
    {
        private readonly Mapper _mapper;
        private readonly TestFixture? _fixture;

        public AutoMapperTest(TestFixture testFixture)
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _mapper = testFixture.ServiceProvider.GetService<Mapper>();
            _fixture = testFixture;
        }

        [Fact]
        public void AutoMapper_MapUserApiModelOnUserCreateApiModel_OK()
        {
            //assign
            var user=_fixture.CreateUserCreateApiModel();
            var userApi = _fixture.CreateUserApiModel(user);

            //act
            //ToDo:var mapUserApi = _mapper.Map<UserCreateApiModel>(userApi);

            //assert
            //ToDo: mapUserApi.Should().BeAssignableTo<UserCreateApiModel>();

        }

        [Fact]
        public void AutoMapper_IsMappingConfiguration_Valid()
        {
            //assign
            var configuration = new MapperConfiguration(cfg =>
                                cfg.AddProfile<MappingProfile>());
           

            //act-assert
            configuration.AssertConfigurationIsValid();
        }
    }
}

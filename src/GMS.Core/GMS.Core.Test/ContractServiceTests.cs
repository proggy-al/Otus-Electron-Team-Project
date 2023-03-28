using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using AutoFixture;
using static System.Linq.Enumerable;
using Shouldly;

namespace GMS.Core.Test
{ 
    public class ContractServiceTests : IClassFixture<TestFixture>
    {
        private readonly ContractService _contractService;
        private readonly Mock<IContractRepository> _repositoryMock = new Mock<IContractRepository>();
        private readonly Guid _id = Guid.NewGuid();
        private IMapper _mapper;
        private List<Contract> FakeContracts;

        public ContractServiceTests(TestFixture testFixture)
        {
            FakeContracts = new List<Contract>();
            foreach(var i in Range(1,5))
            {
                var fixture = new Fixture();
                var entity = fixture.Build<Contract>().Without(e => e.Product).Create();
                entity.StartDate = new DateTime(2023, 10, 10);
                FakeContracts.Add(entity);
            };

            FakeContracts.First().Id = _id;
            _mapper = testFixture.ServiceProvider.GetService<IMapper>();
            _contractService = new ContractService(_mapper, _repositoryMock.Object);
        }

        [Fact]
        public async Task GetPage_ReturnsValid_For_ValidFirsPage()
        {
            _repositoryMock.Setup(m => m.GetPagedAsync(1, 2)).Returns(Task.FromResult(FakeContracts.Take(2).ToList()));

            var result = await _contractService.GetPage(1, 2);
            Assert.NotNull(result);
            Assert.True(result.Count == 2);
            Assert.Equal(result.First().Id, _id);
            Assert.All<ContractDto>(result, e =>
            {
                if (e.StartDate != new DateTime(2023, 10 ,10))
                {
                    Assert.Fail("Fail Date");
                }
            });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public async Task GetPage_ReturnsValid_For_ValidPages(int page)
        {
            _repositoryMock.Setup(m => m.GetPagedAsync(1, 2)).Returns(Task.FromResult(FakeContracts.Take(2).ToList()));
            _repositoryMock.Setup(m => m.GetPagedAsync(3, 2)).Returns(Task.FromResult(FakeContracts.Skip(4).Take(2).ToList()));

            var result = await _contractService.GetPage(page, 2);

            Assert.NotNull(result);
            result.ShouldNotBeNull();
            result.First().StartDate.ShouldBe(new DateTime(2023, 10, 10), "Значение Start Date Не совпадает");
            if (page == 1)
            {
                Assert.True(result.Count == 2);
            }
            if(page == 3) 
            {
                Assert.True(result.Count == 1);
            }
        }
    }
}

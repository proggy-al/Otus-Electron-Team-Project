using Moq;
using AutoMapper;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.BusinessLogic.Services;
using GMS.Core.Core.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using static System.Linq.Enumerable;

namespace GMS.Core.Test.ServicesTests
{
    [Collection("ContractTests")]
    public class ContractServiceTests
    {
        private readonly ContractService _contractService;

        private readonly Mock<IContractRepository> _contractRepositoryMock = new Mock<IContractRepository>();
        private readonly Mock<IFitnessClubRepository> _fitnessClubRepositoryMock = new Mock<IFitnessClubRepository>();
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new Mock<IEmployeeRepository>();

        private readonly FitnessClub _fitnessClub;
        private readonly Manager _manager;
        private readonly List<Contract> _contracts;

        public ContractServiceTests(TestFixture testFixture)
        {
            _fitnessClub = testFixture.FitnessClub;
            _manager = testFixture.Manager;
            _contracts = testFixture.Contracts;

            var mapper = testFixture.ServiceProvider.GetService<IMapper>();
            _contractService = new ContractService(mapper, _contractRepositoryMock.Object, _fitnessClubRepositoryMock.Object, _employeeRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1,12)]
        [InlineData(2,6)]
        [InlineData(4,5)]
        public async Task GetPageApproved_ReturnsContracts(int pageNumber, int pageSize)
        {
            // Arrange
            var approvedContracts = _contracts.Where(c => c.IsApproved == true).ToList();
            var startDate = approvedContracts.FirstOrDefault().StartDate;

            _fitnessClubRepositoryMock.Setup(m => m.GetAsync(_fitnessClub.Id, true))
                .Returns(Task.FromResult(_fitnessClub));

            _employeeRepositoryMock.Setup(m => m.IsEmployeeWorkingInFitnessClub(_fitnessClub.Id, _manager.Id))
                .Returns(Task.FromResult(true));

            _contractRepositoryMock.Setup(m => m.GetPageAsync(_fitnessClub.Id, pageNumber, pageSize, true))
                .Returns(Task.FromResult(new PagedList<Contract>
                {
                    Entities = approvedContracts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                    Pagination = new Pagination(approvedContracts.Count, pageNumber, pageSize)
                }));

            // Act
            var result = await _contractService.GetPageApproved(_manager.Id, _fitnessClub.Id, pageNumber, pageSize);

            // Assert
            Assert.NotNull(result);

            if (pageNumber == 1)
            {
                Assert.True(result.Entities.Count == pageSize);
                Assert.True(result.Pagination.TotalCount == approvedContracts.Count);
                Assert.True(result.Pagination.CurrentPage == pageNumber);
                Assert.True(result.Pagination.PageSize == pageSize);
            }

            foreach (var contractDto in result.Entities)
                Assert.Equal(contractDto.ManagerId, _manager.Id);
            foreach (var contractDto in result.Entities)
                Assert.True(contractDto.IsApproved);

            Assert.All(result.Entities, c =>
            {
                if (c.StartDate != startDate)
                    Assert.Fail("Invalid value of StartDate.");
            });
        }

        [Theory]
        [InlineData(1, 12)]
        [InlineData(2, 6)]
        [InlineData(4, 5)]
        public async Task GetPageNotApproved_ReturnsContracts(int pageNumber, int pageSize)
        {
            // Arrange
            var notApprovedContracts = _contracts.Where(c => c.IsApproved == false).ToList();
            var startDate = notApprovedContracts.FirstOrDefault().StartDate;

            _fitnessClubRepositoryMock.Setup(m => m.GetAsync(_fitnessClub.Id, true))
                .Returns(Task.FromResult(_fitnessClub));

            _employeeRepositoryMock.Setup(m => m.IsEmployeeWorkingInFitnessClub(_fitnessClub.Id, _manager.Id))
                .Returns(Task.FromResult(true));

            _contractRepositoryMock.Setup(m => m.GetPageAsync(_fitnessClub.Id, pageNumber, pageSize, false))
                .Returns(Task.FromResult(new PagedList<Contract>
                {
                    Entities = notApprovedContracts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                    Pagination = new Pagination(notApprovedContracts.Count, pageNumber, pageSize)
                }));

            // Act
            var result = await _contractService.GetPageNotApproved(_manager.Id, _fitnessClub.Id, pageNumber, pageSize);

            // Assert
            Assert.NotNull(result);

            if (pageNumber == 1)
            {
                Assert.True(result.Entities.Count == pageSize);
                Assert.True(result.Pagination.TotalCount == notApprovedContracts.Count);
                Assert.True(result.Pagination.CurrentPage == pageNumber);
                Assert.True(result.Pagination.PageSize == pageSize);
            }

            /*foreach (var contractDto in result.Entities)
                Assert.Equal(contractDto.ManagerId, _manager.Id);*/
            foreach (var contractDto in result.Entities)
                Assert.False(contractDto.IsApproved);

            Assert.All(result.Entities, c =>
            {
                if (c.StartDate != startDate)
                    Assert.Fail("Invalid value of StartDate.");
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.Core.Domain;
using System.Collections.Generic;

namespace GMS.Core.Test.RepositoriesTests
{
    [Collection("ContractTests")]
    public class ContractRepositoryTests
    {
        private readonly IContractRepository _contractRepository;

        private readonly FitnessClub _fitnessClub;
        private readonly Manager _manager;
        private readonly List<Contract> _contracts;

        public ContractRepositoryTests(TestFixture testFixture)
        {
            _fitnessClub = testFixture.FitnessClub;
            _manager = testFixture.Manager;
            _contracts = testFixture.Contracts;

            _contractRepository = testFixture.ServiceProvider.GetService<IContractRepository>();
        }

        [Theory]
        [InlineData(1, 12, true)]
        [InlineData(1, 12, false)]
        [InlineData(3, 12, true)]
        public async void GetPagedAsync_ReturnsContracts(int pageNumber, int pageSize, bool IsApproved)
        {
            // Arrange
            var id = _fitnessClub.Id;
            var contracts = _contracts.Where(c => c.IsApproved == IsApproved).ToList();
            var startDate = contracts.FirstOrDefault().StartDate;

            // Act
            var result = await _contractRepository.GetPageAsync(id, pageNumber, pageSize, IsApproved);

            // Assert
            Assert.NotNull(result);

            if (pageNumber == 1)
            {
                Assert.True(result.Entities.Count == pageSize);
                Assert.True(result.Pagination.TotalCount == contracts.Count);
                Assert.True(result.Pagination.CurrentPage == pageNumber);
                Assert.True(result.Pagination.PageSize == pageSize);
            }

            foreach (var contractDto in result.Entities)
                Assert.Equal(contractDto.ManagerId, _manager.Id);
            foreach (var contractDto in result.Entities)
                Assert.Equal(contractDto.IsApproved, IsApproved);

            Assert.All(result.Entities, c =>
            {
                if (c.StartDate != startDate)
                    Assert.Fail("Invalid value of StartDate.");
            });
        }
    }
}

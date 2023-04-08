
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;

namespace GMS.Core.Test
{
    public class ContractRepositoryTests : IClassFixture<TestFixture>
    {
        private readonly IContractRepository _contractRepository;

        private readonly FitnessClub _fitnessClub;

        public ContractRepositoryTests(TestFixture testFixture)
        {
            var serviceProvider = testFixture.ServiceProvider;
            _contractRepository = serviceProvider.GetService<IContractRepository>();
            _fitnessClub = testFixture.fitnessClub;
        }

        [Fact]
        public async void GetPagedAsync_ReturnsValid_ForValidparams()
        {
            var result = await _contractRepository.GetPageAsync(_fitnessClub.Id, 1, 2,true);

            result.Entities.Count.ShouldBe(2);
        }
    }
}

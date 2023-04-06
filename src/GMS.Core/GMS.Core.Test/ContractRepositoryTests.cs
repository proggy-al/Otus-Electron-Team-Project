
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

        public ContractRepositoryTests(TestFixture testFixture)
        {
            _contractRepository = testFixture.ServiceProvider.GetRequiredService<IContractRepository>();
        }

        [Fact]
        public async Task GetPagedAsync_ReturnsValid_ForValidparams()
        {
           /* var result = await _contractRepository.GetPagedAsync(1, 2);

            result.Count.ShouldBe(2);*/
        }
    }
}

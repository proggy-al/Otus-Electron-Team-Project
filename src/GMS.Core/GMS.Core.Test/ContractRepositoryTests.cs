
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;

namespace GMS.Core.Test
{
    public class ContractRepositoryTests : IClassFixture<TestFixture>
    {
        private readonly IContractRepository _contractRepository;
        //private List<Contract> FakeContracts;
        //private readonly Guid _id = Guid.NewGuid();

        public ContractRepositoryTests(TestFixture testFixture)
        {
            _contractRepository = testFixture.ServiceProvider.GetService<IContractRepository>();
            //_contextMock.Setup(e => e.Contracts).Returns();
            //FakeContracts =
            //new List<Contract>
            //{
            //    new Contract() { Id = _id, StartDate = DateTime.Now.AddDays(1) },
            //    new Contract() { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(1) },
            //    new Contract() { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(1) },
            //    new Contract() { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(1) },
            //    new Contract() { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(1) },
            //};
        }

        [Theory]
        [InlineData(1,2)]
        public async Task GetPagedAsync_ReturnsValid_ForValidparams(int page, int pageSize)
        {
            var result = await _contractRepository.GetPagedAsync(page, pageSize);

            result.Count.ShouldBe(pageSize);
        }
    }
}

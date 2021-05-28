using System.Transactions;
using System;
using Xunit;
using Moq;
using FluentAssertions;
using Troupon.DealManagement.Core.Application.Commands;
using Troupon.DealManagement.Core.Domain.Entities.Deal;
using Infra.Persistence.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using Troupon.DealManagement.Core.Domain.Dtos;

namespace Troupon.DealManagement.Core.Application.Tests.Commands
{
  public class CreateDealCommandTest
  {

    [Fact]
    public async Task GivenEmptyDealShouldFail()
    {
      //Given
      //var mockMapper= new AutoMapper.Mapper();
      var mockWriteRepo = new Mock<IWriteRepository<Deal>>().Object;
      var mockMapper = new Mock<IMapper>().Object;
      var handler = new CreateDealCommand.CreateDealCommandHandler(mockWriteRepo, mockMapper);
      var createDealCommand = new CreateDealCommand()
      {
        Description = "product 1",
        Title = "title",
        ExpirationDate = DateTime.UtcNow,
        OtherConditions = "conditions",
        Limitation = 10
      };
      //When
      var result = await handler.Handle(createDealCommand, new CancellationToken());

      //Then
      result.Title.Should().Contain(createDealCommand.Title);
      result.Should().BeEquivalentTo(createDealCommand, options => options.ComparingByValue<DealDto>().ExcludingMissingMembers());

    }
    [Fact]
    public void TestName()
    {
      //Given

      //When

      //Then
    }
  }
}

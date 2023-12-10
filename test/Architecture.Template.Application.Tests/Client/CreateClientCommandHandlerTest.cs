using System.Threading;
using System.Threading.Tasks;
using Application.Client.Commands.CreateClient;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repository;
using FluentAssertions;
using Moq;
using Xunit;

namespace Application.UnitTests.Client;
[Collection("Client")]
public class CreateClientCommandHandlerTest
{
    public CreateClientCommandHandlerTest()
    {

    }
    [Fact(DisplayName = "GIVEN a createTodoItemCommand valid WHEN createcommandhandler call occur THEN return the client id")]
    public async Task ShouldCreateSuccesfullyClient()
    {
        //Arrange
        var fixture = new Fixture();
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        fixture.Customize<CreateClientCommand>(x =>
        x.With(p => p.Email, "valid@email.com")
        .With(p => p.PhoneNumber, 123456789));

        var command = fixture.Create<CreateClientCommand>();

        fixture.Customize<ClientEntity>(x =>
        x.With(p => p.Email, "valid@email.com")
        .With(p => p.PhoneNumber, 123456789));

        var entityToCreate = fixture.Create<ClientEntity>();
        var clientRepository = new Mock<IClientRepository>(MockBehavior.Strict);
        var mapper = new Mock<IMapper>(MockBehavior.Strict);
        var cancellationToken = new CancellationToken();

        clientRepository.Setup(x => x.InsertAsync(It.IsAny<ClientEntity>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(entityToCreate);

        mapper.Setup(x => x.Map<CreateClientCommand, ClientEntity>(It.IsAny<CreateClientCommand>()))
              .Returns(entityToCreate);

        var commandHandler = new CreateClientCommandHandler(clientRepository.Object,
                                                            mapper.Object);
        //Act
        var entityResponse = await commandHandler.Handle(command, cancellationToken);
        //Assert
        entityToCreate.Email.Should().Be(command.Email);
        entityToCreate.PhoneNumber.Should().Be(command.PhoneNumber);
        entityToCreate.Id.Should().Be(entityResponse);
        clientRepository.Verify(x => x.InsertAsync(It.IsAny<ClientEntity>(), It.IsAny<CancellationToken>()), Times.Once());
        mapper.Verify(x => x.Map<CreateClientCommand, ClientEntity>(It.IsAny<CreateClientCommand>()), Times.Once());
    }
    //[Fact(DisplayName = "Dado que o objeto CreateTodoItemCommand é valido, quando o metodo create é chamado, então deverá retornar TodoItemEntity.Id valido")]
    //public async Task Given_CreateTodoItemCommandValid_When_CallingCreate_Then_ReturnTodoItemEntityGuidValid()
    //{
    //    //Arrange
    //    var fixture = new Fixture();

    //    fixture.Customize<CreateClientCommand>(c =>
    //        c.With(p => p.ListId, Guid.Parse("2f02ffb6-1769-4ef1-80d5-07fe4b64db15"))
    //        .With(p => p.Title, "teste"));

    //    var request = fixture.Create<CreateTodoItemCommand>();

    //    fixture.Customize<TodoItemEntity>(c =>
    //        c.With(p => p.ListId, Guid.Parse("2f02ffb6-1769-4ef1-80d5-07fe4b64db15"))
    //        .With(p => p.Title, "teste")
    //        .With(p => p.Id, Guid.Parse("fe87aa6d-4ec8-4224-af21-59d8acffdf60")));

    //    var entityToCreate = fixture.Create<TodoItemEntity>();

    //    var todoItemRepository = new Mock<IClientRepository>();

    //    var cancelationToken = new CancellationToken();

    //    todoItemRepository.Setup(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(entityToCreate);

    //    var commandHandler = new CreateTodoItemCommandHandler(todoItemRepository.Object);

    //    //Act
    //    var entityResponse = await commandHandler.Handle(request, cancelationToken);

    //    //Assert
    //    entityToCreate.Title.Should().Be(request.Title);
    //    entityToCreate.ListId.Should().Be(request.ListId);
    //    entityToCreate.Id.Should().Be(entityResponse);
    //    todoItemRepository.Verify(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()), Times.Once);
    //}
}

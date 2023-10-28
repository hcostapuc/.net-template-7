using System;
using System.Threading;
using System.Threading.Tasks;
using Application.TodoItem.Commands.CreateTodoItem;
using AutoFixture;
using Domain.Entities;
using Domain.Interfaces.Repository;
using FluentAssertions;
using Moq;
using Xunit;

namespace Application.UnitTests.TodoItem;

[Collection("Testing TodoItemCommand")]
public class CreateTodoItemCommandHandlerTest
{
    public CreateTodoItemCommandHandlerTest()
    {

    }

    [Fact(DisplayName = "Dado que o objeto CreateTodoItemCommand é valido, quando o metodo create é chamado, então deverá retornar TodoItemEntity.Id valido")]
    public async Task Given_CreateTodoItemCommandValid_When_CallingCreate_Then_ReturnTodoItemEntityGuidValid()
    {
        //Arrange
        var fixture = new Fixture();

        fixture.Customize<CreateTodoItemCommand>(c =>
            c.With(p => p.ListId, Guid.Parse("2f02ffb6-1769-4ef1-80d5-07fe4b64db15"))
            .With(p => p.Title, "teste"));

        var request = fixture.Create<CreateTodoItemCommand>();

        fixture.Customize<TodoItemEntity>(c =>
            c.With(p => p.ListId, Guid.Parse("2f02ffb6-1769-4ef1-80d5-07fe4b64db15"))
            .With(p => p.Title, "teste")
            .With(p => p.Id, Guid.Parse("fe87aa6d-4ec8-4224-af21-59d8acffdf60")));

        var entityToCreate = fixture.Create<TodoItemEntity>();

        var todoItemRepository = new Mock<ITodoItemRepository>();

        var cancelationToken = new CancellationToken();

        todoItemRepository.Setup(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entityToCreate);

        var commandHandler = new CreateTodoItemCommandHandler(todoItemRepository.Object);

        //Act
        var entityResponse = await commandHandler.Handle(request, cancelationToken);

        //Assert
        entityToCreate.Title.Should().Be(request.Title);
        entityToCreate.ListId.Should().Be(request.ListId);
        entityToCreate.Id.Should().Be(entityResponse);
        todoItemRepository.Verify(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "Dado que o objeto CreateTodoItemCommand é invalido, quando o metodo create é chamado, então deverá retorar TodoItemEntity.Id invalido")]
    public async Task Given_CreateTodoItemCommandInvalid_When_CallingCreate_Then_ReturnTodoItemEntityGuidInvalid()
    {
        //Arrange
        var fixture = new Fixture();

        fixture.Customize<CreateTodoItemCommand>(c =>
            c.With(p => p.ListId, Guid.Empty)
            .With(p => p.Title, "testFail"));

        var request = fixture.Create<CreateTodoItemCommand>();

        fixture.Customize<TodoItemEntity>(c =>
            c.With(p => p.ListId, Guid.Parse("fe87aa6d-4ec8-4224-af21-59d8acffdf60"))
            .With(p => p.Title, "teste"));

        var entityToCreate = fixture.Create<TodoItemEntity>();

        var todoItemRepository = new Mock<ITodoItemRepository>();

        var cancelationToken = new CancellationToken();

        todoItemRepository.Setup(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entityToCreate);

        var commandHandler = new CreateTodoItemCommandHandler(todoItemRepository.Object);

        //Act
        var entityResponse = await commandHandler.Handle(request, cancelationToken);

        //Assert
        entityResponse.Should().BeEmpty();
        entityToCreate.ListId.Should().NotBe(request.ListId);
        entityToCreate.Title.Should().NotBe(request.Title);
        todoItemRepository.Verify(x => x.InsertAsync(It.IsAny<TodoItemEntity>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
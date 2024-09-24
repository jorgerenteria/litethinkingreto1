using Application.Common.Utils;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Application.UseCases.TodoList.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.TodoList.Commands.CreateToDoList;

public class CreateToDoListCommand : CreateToDoListCommandModel, IRequest<Result<CreateToDoListCommandDto>>
{
    public class CreateToDoListCommandHandler(
        IConfiguration configuration) : UseCaseHandler, IRequestHandler<CreateToDoListCommand, Result<CreateToDoListCommandDto>>
    {
        public async Task<Result<CreateToDoListCommandDto>> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            var repository = new ToDoListRepository(configuration);
            var result = repository.Create(new ToDoListEntity
            { 
                Id = request.ToDoList.Id,
                Description = request.ToDoList.Description,
                IsCompleted = request.ToDoList.IsCompleted,
                Title = request.ToDoList.Title,
            });

            var resultData = new CreateToDoListCommandDto { Created = result };

            return Succeded(resultData);
        }
    }
}


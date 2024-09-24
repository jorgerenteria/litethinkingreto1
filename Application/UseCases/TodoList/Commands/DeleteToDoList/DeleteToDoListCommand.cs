using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Application.UseCases.TodoList.Commands.DeleteToDoList;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TodoList.Commands.DeleteToDoList
{
    public class DeleteToDoListCommand : DeleteToDoListCommandModel, IRequest<Result<DeleteToDoListCommandDto>>
    {
        public class DeleteToDoListCommandHandler(
            IConfiguration configuration) : UseCaseHandler, IRequestHandler<DeleteToDoListCommand, Result<DeleteToDoListCommandDto>>
        {
            public async Task<Result<DeleteToDoListCommandDto>> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
            {
                var repository = new ToDoListRepository(configuration);
                var result = repository.Delete(new ToDoListEntity
                {
                    Id = request.ToDoList.Id,
                });

                if (result)
                {
                    var resultData = new DeleteToDoListCommandDto { Deleted = result };

                    return Succeded(resultData);
                }

                return Invalid<DeleteToDoListCommandDto>("El id que ingresaste no existe");
                
            }
        }
    }
}

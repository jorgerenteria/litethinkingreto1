using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Application.UseCases.TodoList.Commands.DeleteToDoList;
using Application.UseCases.TodoList.Commands.UpdateToDoList;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TodoList.Commands.UpdateToDoList
{
    public class UpdateToDoListCommand : UpdateToDoListCommandModel, IRequest<Result<UpdateToDoListCommandDto>>
    {
        public class UpdateToDoListCommandHandler(
            IConfiguration configuration) : UseCaseHandler, IRequestHandler<UpdateToDoListCommand, Result<UpdateToDoListCommandDto>>
        {
            public async Task<Result<UpdateToDoListCommandDto>> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
            {
                var repository = new ToDoListRepository(configuration);

                var entity = repository.GetById(request.ToDoList.Id);

                if (entity == null)
                {

                    return Invalid<UpdateToDoListCommandDto>("El id no existe");
                }

                var result = repository.Update(new ToDoListEntity
                {
                    Id = request.ToDoList.Id,
                    Description = request.ToDoList.Description,
                    IsCompleted = request.ToDoList.IsCompleted,
                    Title = request.ToDoList.Title,
                });               

                if (result)
                {
                    var resultData = new UpdateToDoListCommandDto { Updated = result };

                    return Succeded(resultData);
                }

                return Invalid<UpdateToDoListCommandDto>("No se pudo actualizar el registro");
            }
        }
    }
}

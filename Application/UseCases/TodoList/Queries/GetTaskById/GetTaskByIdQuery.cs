using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Application.UseCases.TodoList.Commands.CreateToDoList;
using Application.UseCases.TodoList.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TodoList.Queries.GetTaskById
{
    public class GetTaskByIdQuery : GetTaskByIdQueryModel, IRequest<Result<GetTaskByIdDto>>
    {
        public class GetTaskByIdQueryHandler(
            IConfiguration configuration) : UseCaseHandler, IRequestHandler<GetTaskByIdQuery, Result<GetTaskByIdDto>>
        {
            public async Task<Result<GetTaskByIdDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
            {
                var repository = new ToDoListRepository(configuration);
                var result = repository.GetById(request.Id);

                if(result != null)
                {
                    var resultData = new GetTaskByIdDto
                    {
                        Id = result.Id,
                        Description = result.Description,
                        IsCompleted = result.IsCompleted,
                        Title = result.Title,
                    };

                    return Succeded(resultData);
                }

                return Invalid<GetTaskByIdDto>("El id que ingresaste no existe");
            }
        }
    }
}

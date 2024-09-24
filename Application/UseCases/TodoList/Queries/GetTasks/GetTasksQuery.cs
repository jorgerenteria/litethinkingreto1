using Application.Common.Models;
using Application.Common.Utils;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Application.UseCases.Files.Queries.GetFilesNames;
using Application.UseCases.Transactions.Queries.GetTransactions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TodoList.Queries.GetTasks
{
    public class GetTasksQuery : GetTasksQueryModel, IRequest<Result<List<GetTasksDto>>>
    {
        public class GetFilesNamesQueryHandler(
        IConfiguration configuration) : UseCaseHandler, IRequestHandler<GetTasksQuery, Result<List<GetTasksDto>>>
        {
            public async Task<Result<List<GetTasksDto>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
            {
                var repository = new ToDoListRepository(configuration);
                var resultData = repository.GetAll(request.Page, request.PageSize);

                return this.Succeded(resultData.Select(r => new GetTasksDto { Id = r.Id, Description = r.Description, Title = r.Title, IsCompleted = r.IsCompleted }).ToList());
            }
        }
    }
}

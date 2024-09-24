using Application.UseCases.Files.Commands.CreateFile;
using Application.UseCases.Files.Queries.GetFilesNames;
using Application.UseCases.TodoList.Commands;
using Application.UseCases.TodoList.Commands.CreateToDoList;
using Application.UseCases.TodoList.Commands.DeleteToDoList;
using Application.UseCases.TodoList.Commands.UpdateToDoList;
using Application.UseCases.TodoList.Queries.GetTaskById;
using Application.UseCases.TodoList.Queries.GetTasks;
using Application.UseCases.Transactions.Queries.GetTransactions;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoList.Controllers
{
    public class ToDoListController : BaseController
    {
        [HttpGet]
        [Route("Get")]
        [Produces(typeof(List<GetTasksDto>))]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] GetTasksQueryModel model)
        {
            var query = this.Mapper.Map<GetTasksQuery>(model);
            var result = await this.Mediator.Send(query);
            return this.FromResult(result);
        }

        [HttpGet]
        [Route("GetById")]
        [Produces(typeof(GetTaskByIdDto))]
        [ActionName(nameof(GetById))]
        public async Task<IActionResult> GetById([FromQuery] GetTaskByIdQueryModel model)
        {
            var query = this.Mapper.Map<GetTaskByIdQuery>(model);
            var result = await this.Mediator.Send(query);
            return this.FromResult(result);
        }

        [HttpPost]
        [Route("Create")]
        [Produces(typeof(CreateToDoListCommandDto))]
        [ActionName(nameof(Create))]
        public async Task<IActionResult> Create(CreateToDoListCommandModel model)
        {
            var command = this.Mapper.Map<CreateToDoListCommand>(model);
            var result = await this.Mediator.Send(command);
            return this.FromResult(result);
        }

        [HttpPut]
        [Route("Update")]
        [Produces(typeof(UpdateToDoListCommandDto))]
        [ActionName(nameof(Update))]
        public async Task<IActionResult> Update(UpdateToDoListCommandModel model)
        {
            var command = this.Mapper.Map<UpdateToDoListCommand>(model);
            var result = await this.Mediator.Send(command);
            return this.FromResult(result);
        }

        [HttpDelete]
        [Route("Delete")]
        [Produces(typeof(UpdateToDoListCommandDto))]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> Delete(DeleteToDoListCommandModel model)
        {
            var command = this.Mapper.Map<DeleteToDoListCommand>(model);
            var result = await this.Mediator.Send(command);
            return this.FromResult(result);
        }
    }
}

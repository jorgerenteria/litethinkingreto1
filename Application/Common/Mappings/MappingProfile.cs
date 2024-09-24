using Application.UseCases.Files.Commands.CreateFile;
using Application.UseCases.TodoList.Commands;
using Application.UseCases.TodoList.Commands.CreateToDoList;
using Application.UseCases.TodoList.Commands.DeleteToDoList;
using Application.UseCases.TodoList.Commands.UpdateToDoList;
using Application.UseCases.TodoList.Queries.GetTaskById;
using Application.UseCases.TodoList.Queries.GetTasks;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<CreateFileCommandModel, CreateFileCommand>();
        this.CreateMap<CreateToDoListCommandModel, CreateToDoListCommand>();
        this.CreateMap<UpdateToDoListCommandModel, UpdateToDoListCommand>();
        this.CreateMap<DeleteToDoListCommandModel, DeleteToDoListCommand>();
        this.CreateMap<GetTaskByIdQueryModel, GetTaskByIdQuery>();
        this.CreateMap<GetTasksQueryModel, GetTasksQuery>();
        this.CreateMap<ToDoListEntity, GetTasksDto>();
        this.CreateMap<CreateToDoListCommandValueModel, ToDoListEntity>();
    }
}

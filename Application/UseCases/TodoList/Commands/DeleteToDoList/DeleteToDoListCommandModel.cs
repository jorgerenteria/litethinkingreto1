using Application.UseCases.TodoList.Commands.UpdateToDoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TodoList.Commands.DeleteToDoList
{
    public class DeleteToDoListCommandModel
    {
        public DeleteToDoListCommandValueModel? ToDoList { get; set; }
    }
}

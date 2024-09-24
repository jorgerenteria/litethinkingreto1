using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TodoList.Queries.GetTasks
{
    public class GetTasksQueryModel
    {
        public int? Page { get; set; }

        public int? PageSize { get; set; }        
    }
}

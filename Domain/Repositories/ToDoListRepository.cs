using Domain.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Domain.Repositories
{
    public class ToDoListRepository(IConfiguration configuration)
    {
        public List<ToDoListEntity> GetAll(int? page, int? pageSize) {

            var defaultPageSize = pageSize.HasValue ? pageSize.Value : 10;
            var pageNumber = page.HasValue ? page.Value : 1;

            var todoLists = new List<ToDoListEntity>();
            try
            {
                using (var db = new ToDoListContext(configuration))
                {
                    todoLists = db.ToDoLists
                    .OrderBy(e => e.Id)
                    .Skip((pageNumber - 1) * defaultPageSize)
                    .Take(defaultPageSize)
                    .ToList();
                }
            }catch(Exception e)
            {
                var a = 0;
            }

            return todoLists;
        }

        public ToDoListEntity GetById(int id)
        {

            var toDoList = default(ToDoListEntity);
            try
            {
                using (var db = new ToDoListContext(configuration))
                {
                    toDoList = db.ToDoLists.FirstOrDefault(t => t.Id == id);
                }
            }
            catch (Exception e)
            {
                var a = 0;
            }

            return toDoList;
        }

        public bool Create(ToDoListEntity entity)
        {
            try
            {
                using (var db = new ToDoListContext(configuration))
                {
                    db.ToDoLists.Add(entity);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Update(ToDoListEntity entity)
        {
            try
            {
                using (var db = new ToDoListContext(configuration))
                {

                    db.Attach(entity);
                    db.Entry(entity).Property(p => p.Id).IsModified = false;
                    db.Entry(entity).Property(p => p.Title).IsModified = true;
                    db.Entry(entity).Property(p => p.Description).IsModified = true;
                    db.Entry(entity).Property(p => p.IsCompleted).IsModified = true;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(ToDoListEntity entity)
        {
            try
            {
                using (var db = new ToDoListContext(configuration))
                {
                    var entityToDelete = new ToDoListEntity { Id = entity.Id };
                    db.Entry(entityToDelete).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}

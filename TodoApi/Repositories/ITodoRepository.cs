using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        Todo Create(Todo todo);
        bool Update(Todo existing, Todo newTodo);
        bool Delete(int id);
    }
}

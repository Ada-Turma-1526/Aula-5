using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAll();
        Todo GetById(int id);
        Todo Create(Todo todo);
        bool Update(Todo existing, Todo newTodo);
        bool Delete(int id);
    }
}

using ToDoLibrary.Models;

namespace ToDoLibrary.DataAccess
{
    public interface ITodoData
    {
        Task CompleteTodo(int assingedTo, int todoId);
        Task<ToDoModel?> Create(int assingedTo, string task);
        Task<List<ToDoModel>> GetAllAssigned(int assingedTo);
        Task<ToDoModel?> GetOneAssigned(int assingedTo, int todoId);
        Task SaveData(int assingedTo, int todoId);
        Task UpdateTask(int assingedTo, int todoId, string task);
    }
}
using ToDoLibrary.Models;

namespace ToDoLibrary.DataAccess;

public class TodoData : ITodoData
{

    private readonly ISqlDataAccess _sql;

    public TodoData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public Task<List<ToDoModel>> GetAllAssigned(int assingedTo)
    {
        return _sql.LoadData<ToDoModel, dynamic>(
            "dbo.spTodo_GetAllAssigned",
            new { AssignedTo = assingedTo },
            "Default");
    }

    public async Task<ToDoModel?> GetOneAssigned(int assingedTo, int todoId)
    {
        var results = await _sql.LoadData<ToDoModel, dynamic>(
            "dbo.spTodo_GetOneAssigned",
            new { AssignedTo = assingedTo, TodoId = todoId },
            "Default");

        return results.FirstOrDefault();
    }

    public async Task<ToDoModel?> Create(int assingedTo, string task)
    {
        var results = await _sql.LoadData<ToDoModel, dynamic>(
            "dbo.spTodo_Create",
            new { AssignedTo = assingedTo, Task = task },
            "Default");

        return results.FirstOrDefault();
    }
    public Task UpdateTask(int assingedTo, int todoId, string task)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spTodo_UpdateTask",
            new { AssignedTo = assingedTo, TodoId = todoId, Task = task },
            "Default");
    }

    public Task CompleteTodo(int assingedTo, int todoId)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spTodo_CompleteTodo",
            new { AssignedTo = assingedTo, TodoId = todoId },
            "Default");
    }

    public Task SaveData(int assingedTo, int todoId)
    {
        return _sql.SaveData<dynamic>(
            "dbo.spTodo_Delete",
            new { AssignedTo = assingedTo, TodoId = todoId },
            "Default");
    }
}

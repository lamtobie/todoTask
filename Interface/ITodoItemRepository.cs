using todoTask.BLL;

namespace todoTask.Interface
{
    public interface ITodoItemRepository
    {
        public IEnumerable<TodoItemDTO> GetTodoItems();
        public Task<int> CreateTodoItem(TodoItemDTO todoItem);
        public Task<TodoItemDTO> GetTodoItem(long id);
        public Task<int> UpdateTodoItem(long id, TodoItemDTO todoItem);
        public Task<int> DeleteTodoItem(long id);
        public Task<int> AssignTask(long id, long userid);
    }
}

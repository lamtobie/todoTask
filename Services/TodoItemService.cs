using Microsoft.EntityFrameworkCore;
using todoTask.BLL;
using todoTask.Models;

namespace todoTask.Services
{
    public class TodoItemService:ITodoItemService
    {
        TodoContext context = new TodoContext();
        public IEnumerable<TodoItemDTO> GetTodoItems()
        {
            List<TodoItemDTO> TodoItemList = null;

            var todoItems = context.TodoItems.ToList();
            if (todoItems != null)
            {
                TodoItemList = new List<TodoItemDTO>();

                foreach (var todoItem in todoItems)
                {
                    TodoItemDTO temp = new TodoItemDTO();
                    temp.Id = todoItem.Id;
                    temp.UserID = todoItem.UserID;
                    temp.Name = todoItem.Name;
                    temp.IsComplete = todoItem.IsComplete;


                    TodoItemList.Add(temp);
                }
            }
            return TodoItemList;
        }
        public async Task<int> CreateTodoItem(TodoItemDTO todoItem)
        {
            TodoItem addTodoItem = new TodoItem();
            addTodoItem.Id = todoItem.Id;
            addTodoItem.Name = todoItem.Name;
            addTodoItem.UserID = todoItem.UserID;
            addTodoItem.IsComplete = todoItem.IsComplete;
            return await context.SaveChangesAsync();
        }
        public async Task<TodoItemDTO> GetTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            TodoItemDTO todoItemDTO = new TodoItemDTO();
            todoItemDTO.Id = todoItem.Id;
            todoItemDTO.Name = todoItem.Name;
            todoItemDTO.UserID = todoItem.UserID;
            todoItemDTO.IsComplete = todoItem.IsComplete;
            return todoItemDTO;
        }
        public async Task<int> UpdateTodoItem(long id, TodoItemDTO todoItem)
        {
            TodoItem updateTodoItem = new TodoItem();
            updateTodoItem.Id = todoItem.Id;
            updateTodoItem.Name = todoItem.Name;
            updateTodoItem.UserID = todoItem.UserID;
            updateTodoItem.IsComplete = todoItem.IsComplete;
            context.Entry(updateTodoItem).State = EntityState.Modified;

            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<int> DeleteTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return 0;
            }

            context.TodoItems.Remove(todoItem);
            return await context.SaveChangesAsync();
        }
        public async Task<int> AssignTask(long id, long userid)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return 0;
            }
            todoItem.UserID = userid;

            context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

            return 0;
        }
        private bool TodoItemExists(long id)
        {
            return context.TodoItems.Any(e => e.Id == id);
        }
    }
}

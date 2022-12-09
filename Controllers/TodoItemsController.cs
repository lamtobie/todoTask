using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoTask.BLL;
using todoTask.Services;

namespace todoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoItemService todoItemService;

        public TodoItemsController()
        {
            todoItemService = new TodoItemService(); ;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IEnumerable<TodoItemDTO>> GetTodoItems()
        {
            return todoItemService.GetTodoItems();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<TodoItemDTO> GetTodoItem(long id)
        {
            return  await todoItemService.GetTodoItem(id);

        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<int> PutTodoItem(long id, TodoItemDTO todoItem)
        {
            return await todoItemService.UpdateTodoItem(id, todoItem);
        }
        [HttpPut("AssignUser/{id},{userid}")]
        public async Task<int> AssignUsser(long id, long userid)
        {
            return  await todoItemService.AssignTask(id, userid);
           
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<int> PostTodoItem(TodoItemDTO todoItem)
        {
            return await todoItemService.CreateTodoItem(todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteTodoItem(long id)
        {
            return  await todoItemService.DeleteTodoItem(id);
          
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using c_sharp_rest_api_todo.Context;
using c_sharp_rest_api_todo.Models;

namespace c_sharp_rest_api_todo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;
    private readonly ILogger<TodoController> _logger;

    public TodoController(TodoContext context, ILogger<TodoController> logger)
    {
        this._context = context;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> All()
    {
        return Ok(this._context.Todos.AsAsyncEnumerable());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> Get(int id)
    {
        Todo? todo = await _context.Todos.FindAsync(id);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> Post(Todo todoItem)
    {
        this._context.Add(todoItem);
        await this._context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Boolean>> Delete(int id)
    {
        Todo? todo = await this._context.Todos.FindAsync(id);

        if (todo == null)
            return NotFound();

        this._context.Todos.Remove(todo);
        await this._context.SaveChangesAsync();

        return Ok(true);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Todo>> Update(int id, [Bind("Title,isComplete")] Todo todoItem)
    {
        Todo? todo = await this._context.Todos.FindAsync(id);
        if (todo == null)
            return NotFound();

        todo.isComplete = todoItem.isComplete;
        todo.Title = todoItem.Title;

        this._context.Update(todo);
        await this._context.SaveChangesAsync();

        return Ok(todo);
    }
}

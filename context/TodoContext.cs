using c_sharp_rest_api_todo.Models;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_rest_api_todo.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
    : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}
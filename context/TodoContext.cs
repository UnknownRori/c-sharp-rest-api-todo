using c_sharp_rest_api_todo.Models;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_rest_api_todo.Context
{
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
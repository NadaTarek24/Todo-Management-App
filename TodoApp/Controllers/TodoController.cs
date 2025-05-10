using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    // The TodoController handles the logic for CRUD operations and status management of Todos.
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;
        // Constructor to inject the AppDbContext for database access
        public TodoController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Index - Retrieves the list of todos with optional filtering and sorting.
        public async Task<IActionResult> Index(
        TodoStatus? status,   // Filter todos by status (Pending, InProgress, Completed)
        TodoPriority? priority, // Filter todos by priority (Low, Medium, High)
        DateTime? fromDate,  // Filter todos due after this date
        DateTime? toDate,  // Filter todos due before this date
        string sortBy = "DueDate", // Default sort by DueDate
        string sortDir = "asc")    // Default sort direction: ascending
        { // Start with all todos in the database
            var todos = _context.Todos.AsQueryable();
            // Apply filters based on the provided parameters
            if (status != null)
                todos = todos.Where(t => t.Status == status);

            if (priority != null)
                todos = todos.Where(t => t.Priority == priority);

            if (fromDate != null)
                todos = todos.Where(t => t.DueDate >= fromDate);

            if (toDate != null)
                todos = todos.Where(t => t.DueDate <= toDate);

            // Apply sorting based on the provided 'sortBy' and 'sortDir' parameters
            todos = (sortBy, sortDir) switch
            {
                ("Title", "asc") => todos.OrderBy(t => t.Title),
                ("Title", "desc") => todos.OrderByDescending(t => t.Title),
                ("Priority", "asc") => todos.OrderBy(t => t.Priority),
                ("Priority", "desc") => todos.OrderByDescending(t => t.Priority),
                ("DueDate", "desc") => todos.OrderByDescending(t => t.DueDate),
                _ => todos.OrderBy(t => t.DueDate),
            };
            // Return the filtered and sorted list of todos to the view
            return View(await todos.ToListAsync());
        }

        // GET: Create - Displays the form to create a new todo.
        public IActionResult Create() => View();
        // POST: Create - Handles the form submission for creating a new todo.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Todo todo)
        {
            // If the model is valid, add the new todo to the database and save changes.
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect back to the todo list
            }
            return View(todo); // If invalid, return to the create form with the provided data
        }

        // GET: Edit - Retrieves the todo by its ID and displays the edit form.
        public async Task<IActionResult> Edit(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            return todo == null ? NotFound() : View(todo);  // If todo not found, return 404 error
        }

        // POST: Edit - Handles the form submission to update an existing todo.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Todo todo)
        {
            // If the provided id doesn't match the todo's id, return 404 error
            if (id != todo.Id)
                return NotFound();
            // If the model is valid, update the todo and save changes
            if (ModelState.IsValid)
            {
                todo.LastModifiedDate = DateTime.UtcNow; // Update the last modified date
                _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect back to the todo list
            }
            return View(todo); // If invalid, return to the edit form with the provided data
        }

        // GET: Delete - Retrieves the todo by its ID and displays the delete confirmation form.
        public async Task<IActionResult> Delete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            return todo == null ? NotFound() : View(todo);  // If todo not found, return 404 error
        }

        // POST: Delete - Handles the deletion of a todo from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
                _context.Todos.Remove(todo); // Remove the todo from the database

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect back to the todo list
        }

        // POST: Start - Changes the status of the todo to "In Progress".
        [HttpPost]
        public async Task<IActionResult> Start(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null && todo.Status == TodoStatus.Pending) // Only start tasks that are pending
            {
                todo.Status = TodoStatus.InProgress; // Update the status to In Progress
                todo.LastModifiedDate = DateTime.UtcNow; // Update the last modified date
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            return RedirectToAction(nameof(Index)); // Redirect back to the todo list
        }

        // POST: Complete - Changes the status of the todo to "Completed".
        [HttpPost]
        public async Task<IActionResult> Complete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                todo.Status = TodoStatus.Completed; // Update the status to Completed
                todo.LastModifiedDate = DateTime.UtcNow; // Update the last modified dat
                await _context.SaveChangesAsync(); // Save changes to the database
            } 
            return RedirectToAction(nameof(Index)); // Redirect back to the todo list
        }
    }
}

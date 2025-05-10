using System.ComponentModel.DataAnnotations;
using TodoApp.Validators; 

namespace TodoApp.Models
{
    // Enum representing the status of a task
    public enum TodoStatus { Pending, InProgress, Completed }
    // Enum representing the priority level of a task
    public enum TodoPriority { Low, Medium, High }

    // Main Todo entity representing a task item
    public class Todo
    {
        // Unique identifier for each task
        public Guid Id { get; set; } = Guid.NewGuid();

        // Required title for the task with a maximum length of 100 characters
        [Required, MaxLength(100)]
        public string Title { get; set; }

        // Optional description for the task
        public string? Description { get; set; }

        // Status of the task: defaults to Pending
        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        // Priority of the task: defaults to Medium
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;

        // Optional due date; must be today or in the future if provided
        [FutureDate(ErrorMessage = "Due date must be today or in the future.")]
        public DateTime? DueDate { get; set; }

        // Automatically set when the task is created
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Automatically updated when the task is modified
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}

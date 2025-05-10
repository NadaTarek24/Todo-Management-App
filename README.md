# Todo Management App

This is a simple Todo Management Web Application built with ASP.NET Core and Bootstrap. It allows users to create, view, update, delete, and filter todo tasks.

## 🚀 How to Run the Project

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/NadaTarek24/todo-app.git
   cd todo-app

2. **Open the Project:**
   Open the solution (.sln file) in Visual Studio 2022

3. **Set Up the Database:**
   Update the connection string in appsettings.json.
   Open the Package Manager Console and run: 
     ```bash
     Update-Database

4. **Run the Application:
   Press F5 or click on Run in your IDE.
   The app will open in your browser 


## ⚙️ Setup Requirements

- .NET 8 SDK
- Visual Studio 2022 or newer (with ASP.NET and EF workloads installed)
- SQL Server 


## ✅ What I Managed to Complete

I successfully implemented all required features and some bonus features as outlined in the task:

✔ Required Features:

- CRUD operations for todos (Create, Read, Update, Delete).

- List todos with status filtering (e.g., All, Completed, Pending, In Progress).

- Added a "Start" button to change a task's status to "In Progress".

- Ability to mark a todo as complete with a single action.

- Basic validation implemented:

  - Title is required.

  - Due date must be a valid future or current date.

- Proper error handling in both the backend and frontend.

✔ Technical Requirements:
This project was built using ASP.NET Core MVC, following a clean and organized structure. All the technical requirements were met as follows:

✅ Backend (.NET Core)
   - Used ASP.NET Core 7/8 to develop the backend using the MVC pattern (Model-View-Controller).
   - Integrated Entity Framework Core for database access and data management.
   - Implemented proper error handling to gracefully manage unexpected scenarios and enhance stability.

✅ Frontend
   - Designed a simple, responsive user interface using Bootstrap for clean visual presentation.
   - Implemented a Todo list with status filtering (All, Pending, In Progress, Completed).
   - Created Create/Edit forms with validation to ensure correct data entry.
   - Added Delete confirmation modals to prevent accidental data loss and improve UX.

⭐ Bonus Features Completed:

- Additional filters:

  - Filter todos by priority (Low, Medium, High).

  - Filter todos by due date range (e.g., this week, custom range).

- Sorting options:

  - Sort by Title, Priority, and DueDate, both ascending and descending.

  - Maintained clean and organized architecture for easy scalability and readability.


## ❗ What I Found Challenging:

- State Retention While Editing:
   -When editing tasks, retaining the task’s original status (especially when switching back to "Pending")
    while keeping other values intact required a more robust solution to ensure data integrity. 
   -Ensuring that changes were correctly handled both in the UI and database proved tricky at times.

- Task Status Management:
   -Implementing the logic to handle multiple task statuses (Pending, In Progress, Completed) and ensuring that the status 
    transitions were smooth, especially with the addition of the "Start" button, was more complex than initially anticipated.
   -The challenge was in maintaining consistent state across both the backend and frontend, ensuring updates were reflected without errors.

- Error Handling and Debugging:
  -Dealing with edge cases where the data might not match expected formats, such as incorrect due dates or failing
   to save updates, was a challenge. 
  -Implementing comprehensive error handling across the application helped, but 
   debugging these issues was time-consuming.

# ToDo API

This project is a minimal API for managing a to-do list, allowing users to perform CRUD operations (Create, Read, Update, Delete) on tasks. The API is secured using JWT Authentication, and CORS is enabled to allow cross-origin requests.

## Routes

1. **GET /tasks** - Retrieve all tasks (requires JWT authentication).
2. **POST /tasks** - Create a new task (requires JWT authentication).
3. **PUT /tasks/{id}** - Update an existing task (requires JWT authentication).
4. **DELETE /tasks/{id}** - Delete a task (requires JWT authentication).

## Getting Started

### Prerequisites

- .NET SDK (6.0 or higher)
- MySQL database

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/todo-api.git
   cd todo-api
Install the dependencies:

bash
Copy code
dotnet restore
Set up your database connection string in appsettings.json:

json
Copy code
{
    "ConnectionStrings": {
        "ToDoDB": "server=localhost;database=todo;user=root;password=yourpassword"
    }
}
Run the application:

bash
Copy code
dotnet watch run
API Endpoints
1. GET /tasks
Retrieve all tasks from the database.
Requires JWT token for authentication.
2. POST /tasks
Add a new task to the database.
Requires JWT token for authentication.
Example request body:
json
Copy code
{
    "name": "Task Name",
    "isComplete": false
}
3. PUT /tasks/{id}
Update an existing task by ID.
Requires JWT token for authentication.
Example request body:
json
Copy code
{
    "name": "Updated Task Name",
    "isComplete": true
}
4. DELETE /tasks/{id}
Delete a task by ID.
Requires JWT token for authentication.
Authentication
The API uses JWT for user authentication. To get a token, you can use the /login and /register endpoints (not shown here, but similar to the example you provided).

CORS
CORS is enabled to allow any origin to access the API, which is useful during development when your frontend is on a different port.

License
This project is licensed under the MIT License - see the LICENSE file for details.

# TodoList Web API

The TodoList Web API is a simple ASP.NET Core application that allows you to manage a list of todo items. It provides endpoints to create, read, update, and delete todo items stored in a MySQL database.

## Prerequisites

Before running the application, make sure you have the following prerequisites installed:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)

## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/jucarmonam/TodoList-with-Chatgpt-.Net.git

2. Navigate to the project directory (yes twice):
   
   ```bash
   cd todoList
   cd todoList

3. Create or edit the appsettings.json file in the project root and configure your MySQL connection string. Replace <your_connection_string> with your MySQL database connection details:
    ```bash
    {
       "ConnectionStrings": {
           "TodoContext": "server=localhost;port=3306;database=todo;user=root;password=<your_password>"
       },
       // ...
   }

4. Open a terminal or command prompt and run the following commands to apply database migrations:
   ```bash
     dotnet ef database update

## Usage
5. Start the application:
   ```bash
   dotnet run

The API will be accessible at https://localhost:5262

## API ENDPOINTS

- GET /api/todoitems: Get a list of all todo items.
- GET /api/todoitems/{id}: Get a specific todo item by ID.
- POST /api/todoitems: Create a new todo item (request body should be in JSON format).
- PUT /api/todoitems/{id}: Update a todo item by ID (request body should be in JSON format).
- DELETE /api/todoitems/{id}: Delete a todo item by ID.

## short feedback
- was it easy to complete the task using AI?:
In some cases, using the AI was really useful to help generate code and configuration, but sometimes the steps that the AI gave me weren't complete, what I mean is that chatgpt forgot to tell me some previous configuration or packages that I needed to have previously installed.
- How long did task take you to complete?
around eight hours
- Was the code ready to run after generation? What did you have to change to make it usable?
Most of the time, the code provided wasn't really functional, for example, the unit tests I had to change a lot to make them work.
- Which challenges did you face during completion of the task?
thougth the solution that chatgpt gave me was really useful, I had to be really cautious, test the things, see why it didn't work, change it and things like that. In the end I think I could have done it faster without the help of chatgpt.
- Which specific prompts you learned as a good practice to complete the task?
Give him a role, Be clear and concise and Provide feedback

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Controllers;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Tests
{
    public class TodoItemsControllerTests : IDisposable
    {
        // Arrange
        DbContextOptions<TodoContext> options = new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        [Fact]
        public async Task GetTodoItems_ReturnsOkResult()
        {

            using (var context = new TodoContext(options))
            {
                context.TodoItems.AddRange(new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Item 1" },
                new TodoItem { Id = 2, Title = "Item 2" },
            });
                context.SaveChanges();
            }

            using (var context = new TodoContext(options))
            {
                var controller = new TodoItemsController(context);

                // Act
                var result = await controller.GetTodoItems();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var items = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(okResult.Value);
                Assert.Equal(2, items.Count());
            }
        }

        [Fact]
        public async Task GetTodoItem_ReturnsOkResult()
        {
            // Arrange

            using (var context = new TodoContext(options))
            {
                context.TodoItems.Add(new TodoItem { Id = 1, Title = "Item 1" });
                context.SaveChanges();
            }

            using (var context = new TodoContext(options))
            {
                var controller = new TodoItemsController(context);

                // Act
                var result = await controller.GetTodoItem(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var item = Assert.IsType<TodoItem>(okResult.Value);
                Assert.Equal(1, item.Id);
            }
        }

        [Fact]
        public async Task PutTodoItem_ReturnsNoContentResult()
        {
            // Arrange

            using (var context = new TodoContext(options))
            {
                context.TodoItems.Add(new TodoItem { Id = 1, Title = "Item 1" });
                context.SaveChanges();
            }

            using (var context = new TodoContext(options))
            {
                var controller = new TodoItemsController(context);
                var updatedItem = new TodoItem { Id = 1, Title = "Updated Item" };

                // Act
                var result = await controller.PutTodoItem(1, updatedItem);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }

        [Fact]
        public async Task PostTodoItem_ReturnsCreatedAtActionResult()
        {
            // Arrange

            using (var context = new TodoContext(options))
            {
                context.TodoItems.Add(new TodoItem { Id = 1, Title = "Item 1" });
                context.SaveChanges();
            }

            using (var context = new TodoContext(options))
            {
                var controller = new TodoItemsController(context);
                var newItem = new TodoItem { Title = "New Item" };

                // Act
                var result = await controller.PostTodoItem(newItem);

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
                var createdItem = Assert.IsType<TodoItem>(createdAtActionResult.Value);
                Assert.Equal("New Item", createdItem.Title);
            }
        }

        [Fact]
        public async Task DeleteTodoItem_ReturnsNoContentResult()
        {
            // Arrange

            using (var context = new TodoContext(options))
            {
                context.TodoItems.Add(new TodoItem { Id = 1, Title = "Item 1" });
                context.SaveChanges();
            }

            using (var context = new TodoContext(options))
            {
                var controller = new TodoItemsController(context);

                // Act
                var result = await controller.DeleteTodoItem(1);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }

        // Dispose of the database context and in-memory database
        public void Dispose()
        {
            using (var context = new TodoContext(options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}

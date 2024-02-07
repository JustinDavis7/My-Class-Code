using Moq;
using NUnit.Framework;
using HW4.Models;
using HW4.DAL.Abstract;
using HW4.DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HW4_Test
{

    public class ToDoTaskRepositoryTests
    {
        private Mock<ToDoDbContext> _mockContext;
        private Mock<DbSet<Person>> _mockPersonDbSet;
        private Mock<DbSet<ItemTask>> _mockItemTaskDbSet;
        private List<Person> _people;
        private List<ToDoItem> _ToDoItems;
        private List<ItemTask> _itemTasks;
        private DateOnly _today;
        private TimeOnly _zeroTime;

        [SetUp]
        public void Setup()
        {
            _today = new DateOnly(2023, 3, 15);
            _zeroTime = new TimeOnly(0, 0, 0);
            _people = new List<Person>
            {
                new Person {Id = 1, FirstName = "Sandra", LastName = "Hart" },
                new Person {Id = 2, FirstName = "Eladio", LastName = "Purnama" },
                new Person {Id = 3, FirstName = "Arjan", LastName = "Dowling" },
                new Person {Id = 4, FirstName = "Owen", LastName = "Hernandez"}
            };
            _ToDoItems = new List<ToDoItem>
            {
                new ToDoItem { Id = 1, Name = "Car", Description = "Tesla Model 3", PersonId = 1 },
                new ToDoItem { Id = 2, Name = "Snake", Description = "Artemis: Ball Python morph butter", PersonId = 1 },
                new ToDoItem { Id = 3, Name = "Furnace", Description = "Air filter", PersonId = 1 },
                new ToDoItem { Id = 4, Name = "Plants", Description = "Indoor plants, living room", PersonId = 2 },
                new ToDoItem { Id = 5, Name = "Taxes", Description = "Property taxes", PersonId = 2 },
                new ToDoItem { Id = 6, Name = "Rubbish", Description = "Bins out front", PersonId = 3 },
                new ToDoItem { Id = 7, Name = "Car", Description = "Rivian RT1", PersonId = 3 }
            };
            _itemTasks = new List<ItemTask>
            {
                // 2 tasks that should appear once within 7 day window
                new ItemTask { Id = 1, Notes = "Change the cabin air filter", FirstCompletion = _today.AddDays(2).ToDateTime(_zeroTime), Frequency = 365, ItemId = 1},
                new ItemTask { Id = 2, Notes = "Rotate the tires",            FirstCompletion = _today.AddDays(5).ToDateTime(_zeroTime), Frequency = 180, ItemId = 1},
                // 2 tasks that should NOT appear within 7 day window
                new ItemTask { Id = 3, Notes = "Vacuum the interior",         FirstCompletion = _today.AddDays(8).ToDateTime(_zeroTime), Frequency = 90, ItemId = 1},
                new ItemTask { Id = 4, Notes = "Wash exterior",               FirstCompletion = _today.AddDays(-20).ToDateTime(_zeroTime), Frequency = 90, ItemId = 1},
                // 2 tasks that should appear multiple times within 7 day window
                new ItemTask { Id = 5, Notes = "Check brakes",                FirstCompletion = _today.AddDays(2).ToDateTime(_zeroTime), Frequency = 2, ItemId = 1},
                new ItemTask { Id = 6, Notes = "Clean windshield",            FirstCompletion = _today.AddDays(0).ToDateTime(_zeroTime), Frequency = 1, ItemId = 1}
            };
            // Set the navigation properties
            _people.ForEach(p => {
                p.ToDoItems = _ToDoItems.Where(s => s.PersonId == p.Id).ToList();  // person to many ToDoItems
            });
            _ToDoItems.ForEach(s =>
            {
                s.Person = _people.Single(p => p.Id == s.PersonId);       // ToDoItem to one person
            });
            _itemTasks.ForEach(st =>
            {
                st.Item = _ToDoItems.Single(s => s.Id == st.ItemId);
            });
            _mockContext = new Mock<ToDoDbContext>();
            _mockPersonDbSet = MockHelpers.GetMockDbSet(_people.AsQueryable());
            _mockContext.Setup(ctx => ctx.People).Returns(_mockPersonDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Person>()).Returns(_mockPersonDbSet.Object);
            _mockItemTaskDbSet = MockHelpers.GetMockDbSet(_itemTasks.AsQueryable());
            _mockContext.Setup(ctx => ctx.ItemTasks).Returns(_mockItemTaskDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<ItemTask>()).Returns(_mockItemTaskDbSet.Object);
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_With2TasksAppearingOnceIn7Days_ReturnsThose2Tasks()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.Any(td => td.Todo.Notes == "Change the cabin air filter"),Is.True);
                Assert.That(todos.Any(td => td.Todo.Notes == "Rotate the tires"), Is.True);
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_With2TasksAppearingOnceIn7Days_ReturnsThose2TasksWithCorrectCalculatedDates()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.Single(td => td.Todo.Notes == "Change the cabin air filter").TodoCalculatedDate, Is.EqualTo(_today.AddDays(2)));
                Assert.That(todos.Single(td => td.Todo.Notes == "Rotate the tires").TodoCalculatedDate, Is.EqualTo(_today.AddDays(5)));
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ShouldNotReturn2TasksOutsideWindow()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.Any(td => td.Todo.Notes == "Vacuum the interior"), Is.False);
                Assert.That(todos.Any(td => td.Todo.Notes == "Wash exterior"), Is.False);
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ShouldReturnMultipleIdenticalTasksForShortInterval()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.Any(td => td.Todo.Notes == "Check brakes"), Is.True);
                Assert.That(todos.Count(td => td.Todo.Notes == "Check brakes"), Is.EqualTo(3));
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ShouldReturnMultipleIdenticalTasksForShortIntervalWithCorrectCalculatedDates()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7)
                                                .Where(td => td.Todo.Notes == "Check brakes")
                                                .OrderBy(td => td.TodoCalculatedDate)         // so we're not testing 2 different things here, only testing the calculated date, not ordering
                                                .ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.ElementAt(0).TodoCalculatedDate, Is.EqualTo(_today.AddDays(2)));
                Assert.That(todos.ElementAt(1).TodoCalculatedDate, Is.EqualTo(_today.AddDays(4)));
                Assert.That(todos.ElementAt(2).TodoCalculatedDate, Is.EqualTo(_today.AddDays(6)));
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ShouldReturnMultipleIdenticalTasksForShortInterval2()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.Any(td => td.Todo.Notes == "Clean windshield"), Is.True);
                Assert.That(todos.Count(td => td.Todo.Notes == "Clean windshield"), Is.EqualTo(8));
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForDateFarInPast_ShouldReturnNoTodos()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today.AddDays(-300);
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.That(todos, Is.Empty);
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForBigWindow_ShouldReturnAllTasksAtLeastOnce()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today.AddDays(-300);
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 500);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todos.Any(td => td.Todo.Notes == "Change the cabin air filter"), Is.True);
                Assert.That(todos.Any(td => td.Todo.Notes == "Rotate the tires"), Is.True);
                Assert.That(todos.Any(td => td.Todo.Notes == "Vacuum the interior"), Is.True);
                Assert.That(todos.Any(td => td.Todo.Notes == "Wash exterior"), Is.True);
                Assert.That(todos.Any(td => td.Todo.Notes == "Check brakes"), Is.True);
                Assert.That(todos.Any(td => td.Todo.Notes == "Clean windshield"), Is.True);
            });
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ShouldReturnTasksInChronologicalOrder()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today.AddDays(-300);
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 500);

            // Assert
            Assert.That(todos, Is.Ordered.By("TodoCalculatedDate"));
        }

        
        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForTodayWithWindowSeven_ShouldReturn13Todos()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.That(todos.Count(),Is.EqualTo(13));
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForTodayWithWindowFive_ShouldReturn10Todos()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 5);

            // Assert
            Assert.That(todos.Count(), Is.EqualTo(10));
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForTodayWithWindowThree_ShouldReturn6Todos()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 3);

            // Assert
            Assert.That(todos.Count(), Is.EqualTo(6));
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForTodayPlusTwoWithWindowFive_ShouldReturn11Todos()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today.AddDays(2);
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 5);

            // Assert
            Assert.That(todos.Count(), Is.EqualTo(11));
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForWayInThePast_ShouldReturn0Todos()
        {
            // Arrange
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today.AddDays(-1000);
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.That(todos.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetAllTasksTodoWithinTimeWindow_ForTasksStartingInThePast_ThatHaveAFrequencyThatPutsThemInTheWindow_ShouldReturnTodos()
        {
            // Arrange
            // A task that starts prior to the window, but has an interval that means it appear within our window
            _itemTasks.Add(new ItemTask { Id = 7, Notes = "Drive it", FirstCompletion = _today.AddDays(-2).ToDateTime(_zeroTime), Frequency = 2, ItemId = 1 });
            _itemTasks.ForEach(st =>
            {
                st.Item = _ToDoItems.Single(s => s.Id == st.ItemId);
            });
            _mockContext = new Mock<ToDoDbContext>();
            _mockItemTaskDbSet = MockHelpers.GetMockDbSet(_itemTasks.AsQueryable());
            _mockContext.Setup(ctx => ctx.ItemTasks).Returns(_mockItemTaskDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<ItemTask>()).Returns(_mockItemTaskDbSet.Object);
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            List<TaskTodo> todos = toDoTaskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

            // Assert
            Assert.That(todos.Count(t => t.Todo.Notes == "Drive it"), Is.EqualTo(4));
        }


    }
}
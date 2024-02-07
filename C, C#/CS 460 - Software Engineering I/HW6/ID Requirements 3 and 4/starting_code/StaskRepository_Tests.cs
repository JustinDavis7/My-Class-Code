using HW6.DAL.Abstract;
using HW6.DAL.Concrete;
using HW6.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Cryptography;

namespace HW6_Tests;

public class StaskRepositoryTests
{
    private Mock<RemindersDbContext> _mockContext;
    private Mock<DbSet<Person>> _mockPersonDbSet;
    private Mock<DbSet<Stask>> _mockStaskDbSet;
    private List<Person> _people;
    private List<Subject> _subjects;
    private List<Stask> _stasks;
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
        _subjects = new List<Subject>
        {
            new Subject { Id = 1, Title = "Car", Description = "Tesla Model 3", OwnerId = 1 },
            new Subject { Id = 2, Title = "Snake", Description = "Artemis: Ball Python morph butter", OwnerId = 1 },
            new Subject { Id = 3, Title = "Furnace", Description = "Air filter", OwnerId = 1 },
            new Subject { Id = 4, Title = "Plants", Description = "Indoor plants, living room", OwnerId = 2 },
            new Subject { Id = 5, Title = "Taxes", Description = "Property taxes", OwnerId = 2 },
            new Subject { Id = 6, Title = "Rubbish", Description = "Bins out front", OwnerId = 3 },
            new Subject { Id = 7, Title = "Car", Description = "Rivian RT1", OwnerId = 3 }
        };
        _stasks = new List<Stask>
        {
            // 2 tasks that should appear once within 7 day window
            new Stask { Id = 1, Todo = "Change the cabin air filter", StartDate = _today.AddDays(2).ToDateTime(_zeroTime), Interval = 365, SubjectId = 1},
            new Stask { Id = 2, Todo = "Rotate the tires",            StartDate = _today.AddDays(5).ToDateTime(_zeroTime), Interval = 180, SubjectId = 1},
            // 2 tasks that should NOT appear within 7 day window
            new Stask { Id = 3, Todo = "Vacuum the interior",         StartDate = _today.AddDays(8).ToDateTime(_zeroTime), Interval = 90, SubjectId = 1},
            new Stask { Id = 4, Todo = "Wash exterior",               StartDate = _today.AddDays(-20).ToDateTime(_zeroTime), Interval = 90, SubjectId = 1},
            // 2 tasks that should appear multiple times within 7 day window
            new Stask { Id = 5, Todo = "Check brakes",                StartDate = _today.AddDays(2).ToDateTime(_zeroTime), Interval = 2, SubjectId = 1},
            new Stask { Id = 6, Todo = "Clean windshield",            StartDate = _today.AddDays(0).ToDateTime(_zeroTime), Interval = 1, SubjectId = 1}
        };
        // Set the navigation properties
        _people.ForEach(p => {
            p.Subjects = _subjects.Where(s => s.OwnerId == p.Id).ToList();  // person to many subjects
        });
        _subjects.ForEach(s =>
        {
            s.Owner = _people.Single(p => p.Id == s.OwnerId);       // subject to one person
        });
        _stasks.ForEach(st =>
        {
            st.Subject = _subjects.Single(s => s.Id == st.SubjectId);
        });
        _mockContext = new Mock<RemindersDbContext>();
        _mockPersonDbSet = MockHelpers.GetMockDbSet(_people.AsQueryable());
        _mockContext.Setup(ctx => ctx.People).Returns(_mockPersonDbSet.Object);
        _mockContext.Setup(ctx => ctx.Set<Person>()).Returns(_mockPersonDbSet.Object);
        _mockStaskDbSet = MockHelpers.GetMockDbSet(_stasks.AsQueryable());
        _mockContext.Setup(ctx => ctx.Stasks).Returns(_mockStaskDbSet.Object);
        _mockContext.Setup(ctx => ctx.Set<Stask>()).Returns(_mockStaskDbSet.Object);
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_With2TasksAppearingOnceIn7Days_ReturnsThose2Tasks()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today;
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(todos.Any(td => td.Todo.Todo == "Change the cabin air filter"),Is.True);
            Assert.That(todos.Any(td => td.Todo.Todo == "Rotate the tires"), Is.True);
        });
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_With2TasksAppearingOnceIn7Days_ReturnsThose2TasksWithCorrectCalculatedDates()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today;
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(todos.Single(td => td.Todo.Todo == "Change the cabin air filter").TodoCalculatedDate, Is.EqualTo(_today.AddDays(2)));
            Assert.That(todos.Single(td => td.Todo.Todo == "Rotate the tires").TodoCalculatedDate, Is.EqualTo(_today.AddDays(5)));
        });
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_ShouldNotReturn2TasksOutsideWindow()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today;
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(todos.Any(td => td.Todo.Todo == "Vacuum the interior"), Is.False);
            Assert.That(todos.Any(td => td.Todo.Todo == "Wash exterior"), Is.False);
        });
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_ShouldReturnMultipleIdenticalTasksForShortInterval()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today;
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(todos.Any(td => td.Todo.Todo == "Check brakes"), Is.True);
            Assert.That(todos.Count(td => td.Todo.Todo == "Check brakes"), Is.EqualTo(3));
        });
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_ShouldReturnMultipleIdenticalTasksForShortIntervalWithCorrectCalculatedDates()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today;
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7)
                                              .Where(td => td.Todo.Todo == "Check brakes")
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
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today;
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(todos.Any(td => td.Todo.Todo == "Clean windshield"), Is.True);
            Assert.That(todos.Count(td => td.Todo.Todo == "Clean windshield"), Is.EqualTo(8));
        });
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_ForDateFarInPast_ShouldReturnNoTodos()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today.AddDays(-300);
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 7);

        // Assert
        Assert.That(todos, Is.Empty);
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_ForBigWindow_ShouldReturnAllTasksAtLeastOnce()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today.AddDays(-300);
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 500);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(todos.Any(td => td.Todo.Todo == "Change the cabin air filter"), Is.True);
            Assert.That(todos.Any(td => td.Todo.Todo == "Rotate the tires"), Is.True);
            Assert.That(todos.Any(td => td.Todo.Todo == "Vacuum the interior"), Is.True);
            Assert.That(todos.Any(td => td.Todo.Todo == "Wash exterior"), Is.True);
            Assert.That(todos.Any(td => td.Todo.Todo == "Check brakes"), Is.True);
            Assert.That(todos.Any(td => td.Todo.Todo == "Clean windshield"), Is.True);
        });
    }

    [Test]
    public void GetAllTasksTodoWithinTimeWindow_ShouldReturnTasksInChronologicalOrder()
    {
        // Arrange
        IStaskRepository staskRepository = new StaskRepository(_mockContext.Object);

        // Act
        DateOnly today = _today.AddDays(-300);
        List<TaskTodo> todos = staskRepository.GetAllTasksTodoWithinTimeWindow(today, 500);

        // Assert
        Assert.That(todos, Is.Ordered.By("TodoCalculatedDate"));
    }

}

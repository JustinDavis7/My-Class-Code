using Moq;
using NUnit.Framework;
using HW4.Models;
using HW4.DAL.Abstract;
using HW4.DAL.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HW4_Test
{

    public class PersonRepository_Tests
    {
        private Mock<ToDoDbContext> _mockContext;
        private Mock<DbSet<Person>> _mockPersonDbSet;
        private List<Person> _users;
        private List<ToDoItem> _items;
        [SetUp]
        public void Setup()
        {
            _users = new List<Person>
            {
                new Person {Id =1, FirstName = "Justin", LastName = "Davis"},
                new Person {Id =2, FirstName = "Justin", LastName = "Tryon"},
                new Person {Id =3, FirstName = "Sandra", LastName = "Hart"},
                new Person {Id =4, FirstName = "Joe", LastName = "Stone"}
            };
            _items = new List<ToDoItem>
            {
                new ToDoItem {Id = 1, Name = "Car", Description = "Personal car, white BMW", PersonId = 1},
                new ToDoItem {Id = 2, Name = "House", Description = "Personal residence", PersonId = 2},
                new ToDoItem {Id = 3, Name = "Dog", Description = "Golden Retriever", PersonId = 1},
                new ToDoItem {Id = 4, Name = "Yard", Description = "Front yard, some grass with lost of clover", PersonId = 3},
            };
            _users.ForEach(p =>
            {
                p.ToDoItems = _items.Where(item => item.PersonId == p.Id).ToList();
            });
            _items.ForEach(i =>
            {
                i.Person = _users.Single(person => person.Id == i.PersonId);
            });

            _mockContext = new Mock<ToDoDbContext>();
            _mockPersonDbSet = MockHelpers.GetMockDbSet(_users.AsQueryable());
            _mockContext.Setup(ctx => ctx.People).Returns(_mockPersonDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Person>()).Returns(_mockPersonDbSet.Object);
        }

        [Test]
        public void PersonRepository_WithValidPerson_ReturnsCorrectPerson()
        {
            // Arrange
            IPersonRepository personRepo = new PersonRepository(_mockContext.Object);
            var expected = _users[0];

            // Act
            var user = personRepo.GetPersonInfo("Justin Davis");

            // Assert
            Assert.That(user, Is.EqualTo(expected));
        }

        [Test]
        public void PersonRepository_WithInValidPerson_ReturnsNull()
        {
            // Arrange
            IPersonRepository personRepo = new PersonRepository(_mockContext.Object);

            // Act
            var user = personRepo.GetPersonInfo("Non Existant");

            // Assert
            Assert.That(user, Is.EqualTo(null));
        }

        [Test]
        public void PersonRepository_WithEmptyStringName_ReturnsNull()
        {
            // Arrange
            IPersonRepository personRepo = new PersonRepository(_mockContext.Object);

            // Act
            var user = personRepo.GetPersonInfo("");

            // Assert
            Assert.That(user, Is.EqualTo(null));
        }
    }
}
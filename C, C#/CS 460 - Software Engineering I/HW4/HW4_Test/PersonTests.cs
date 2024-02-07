using HW4.Models;

namespace HW4_Test
{
    public class Person_Tests
    {
        private Person MakeValidPerson()
        {
            Person person = new Person
            {
                Id = 1,
                FirstName = "Justin",
                LastName = "Davis"
            };
            return person;
        }

        [Test]
        public void ValidPerson_IsValid()
        {
            // Arrange
            Person person = MakeValidPerson();

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.That(mv.Valid, Is.True);
        }

        [Test]
        public void Person_WithMissingFirstName_IsNotValid()
        {
            // Arrange
            Person person = MakeValidPerson();
            person.FirstName = null!;

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("FirstName"), Is.True);
            });
        }

        [Test]
        public void Person_WithEmptyStringForFirstName_IsNotValid()
        {
            // Arrange
            Person person = MakeValidPerson();
            person.FirstName = "";

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("FirstName"), Is.True);
            });
        }

        [Test]
        public void Person_WithTooLongFirstName_IsNotValid()
        {
            // Arrange
            Person person = MakeValidPerson();
            person.FirstName = "PhilipJohannaDeweyKarlCoryConnieBrendanLolaJimmieVivian";

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("FirstName"), Is.True);
            });
        }

        [Test]
        public void Person_WithMissingLastName_IsNotValid()
        {
            // Arrange
            Person person = MakeValidPerson();
            person.LastName = null!;

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("LastName"), Is.True);
            });
        }

        [Test]
        public void Person_WithEmptyStringForLastName_IsNotValid()
        {
            // Arrange
            Person person = MakeValidPerson();
            person.LastName = "";

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("LastName"), Is.True);
            });
        }

        [Test]
        public void Person_WithTooLongLastName_IsNotValid()
        {
            // Arrange
            Person person = MakeValidPerson();
            person.LastName = "PhilipJohannaDeweyKarlCoryConnieBrendanLolaJimmieVivian";

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("LastName"), Is.True);
            });
        }
    }
}
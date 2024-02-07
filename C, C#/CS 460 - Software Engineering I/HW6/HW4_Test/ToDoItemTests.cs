using HW4.Models;

namespace HW4_Test
{
    public class ToDoItem_Tests
    {
        private ToDoItem MakeValidToDoItem()
        {
            ToDoItem item = new ToDoItem
            {
                Id = 1,
                Name = "House",
                Description = "It's my house, what else.",
                PersonId = 1
            };
            return item;
        }

        [Test]
        public void ValidToDoItem_IsValid()
        {
            // Arrange
            ToDoItem item = MakeValidToDoItem();

            // Act
            ModelValidator mv = new ModelValidator(item);

            // Assert
            Assert.That(mv.Valid, Is.True);
        }

        [Test]
        public void Item_WithMissingName_IsNotValid()
        {
            ToDoItem item = MakeValidToDoItem();
            item.Name = null!;

            // Act
            ModelValidator mv = new ModelValidator(item);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("Name"), Is.True);
            });
        }

        [Test]
        public void Item_WithEmptyStringName_IsNotValid()
        {
            ToDoItem item = MakeValidToDoItem();
            item.Name = "";

            // Act
            ModelValidator mv = new ModelValidator(item);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("Name"), Is.True);
            });
        }

        [Test]
        public void Item_WithMissingDescription_IsNotValid()
        {
            ToDoItem item = MakeValidToDoItem();
            item.Description = null!;

            // Act
            ModelValidator mv = new ModelValidator(item);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("Description"), Is.True);
            });
        }

        [Test]
        public void Item_WithEmptyStringDescription_IsNotValid()
        {
            ToDoItem item = MakeValidToDoItem();
            item.Description = "";

            // Act
            ModelValidator mv = new ModelValidator(item);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("Description"), Is.True);
            });
        }
    }
}
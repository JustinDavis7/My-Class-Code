using Final.Models;

namespace Final_Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // Arrange
        int x = 5;
        int y = 10;
        int expected = 15;

        // Act
        int actual = Helpers.Add(x, y);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using MoqClassDemo.Logic;
using MoqClassDemo.Models;
using MoqClassDemo.Services;
using NUnit.Framework;

namespace MoqClassDemo.Test
{
    public class PasswordManagerMockTest : PasswordManagerTestBase
    {

        public PasswordManagerMockTest() : base(new PasswordManager(new MockDataStore()))
        {

        }

        [SetUp]
        public void Setup()
        {
            PasswordManager = new PasswordManager(new MockDataStore());
        }

        [Test]
        public void AddPasswordEntry_ShouldAddValidPassword()
        {
            // Arrange

            // Act
            var result = PasswordManager.Add(GoodPassword);

            // Assert
            Assert.IsTrue(result.ToList().Any(r => r.Equals(PasswordResult.Valid)));

        }

        [Test]
        public void AddPasswordEntry_ShouldNotAddInvalidPassword()
        {
            // Arrange

            // Act
            var result = PasswordManager.Add(BadPassword).ToList();

            // Assert
            Assert.IsFalse(result.Contains(PasswordResult.Valid));
        }

        [Test]
        public void AddPasswordEntry_ShouldNotAddInvalidPasswordCharLimit()
        {
            // Arrange

            // Act
            var result = PasswordManager.Add(BadPassword).ToList();

            // Assert
            Assert.Contains(PasswordResult.InvalidMinCharacterLimit, result);
        }

        [Test]
        public void AddPasswordEntry_ShouldNotAddInvalidPasswordUppercaseLimit()
        {
            // Arrange

            // Act
            var result = PasswordManager.Add(BadPassword).ToList();

            // Assert
            Assert.Contains(PasswordResult.InvalidUppercaseAlphaLimit, result);
        }

        [Test]
        public void AddPasswordEntry_ShouldNotAddInvalidPasswordLowercaseLimit()
        {
            // Arrange

            var badPassword = new PasswordEntry
            {
                UserName = "jondoe@gmail.com",
                Password = "012345A!",
                SiteName = "JoeBlowStore",
                Url = "https://www.joebloestore.com"
            };

            // Act
            var result = PasswordManager.Add(badPassword).ToList();

            // Assert
            Assert.Contains(PasswordResult.InvalidLowercaseAlphaLimit, result);
        }

        [Test]
        public void AddPasswordEntry_ShouldNotAddInvalidPasswordNonAlphaLimit()
        {
            // Arrange

            // Act
            var result = PasswordManager.Add(BadPassword).ToList();

            // Assert
            Assert.Contains(PasswordResult.InvalidNonAlphaNumericLimit, result);
        }

        [Test]
        public void GetPassword_AmazonShouldBeStoredInDataStore()
        {
            // Arrange

            // Act
            PasswordManager.Add(GoodPassword);

            var amazonPasswordEntry = PasswordManager.GetEntry("Amazon");


            // Assert
            Assert.AreEqual(GoodPassword, amazonPasswordEntry);
        }

        [Test]
        public void GetPassword_BobsBurgersShouldBeNotStoredInDataStore()
        {
            // Arrange

            // Act
            PasswordManager.Add(GoodPassword);

            var bobsBurgers = PasswordManager.GetEntry("Bob's Burgers");

            // Assert
            Assert.IsNull(bobsBurgers);
        }

        [Test]
        public void Delete_RemovesValidPassword()
        {
            // Arrange
            PasswordManager.Add(GoodPassword);

            var password = PasswordManager.GetEntry("Amazon");

            var id = password.Id;
            // Act
            PasswordManager.Delete(id);

            // Assert
            Assert.AreEqual(0, PasswordManager.DataStore.Passwords.Count);
        }

        [Test]
        public void Delete_CantFindOldEntry()
        {
            // Arrange
            PasswordManager.Add(GoodPassword);

            var password = PasswordManager.GetEntry("Amazon");

            var id = password.Id;
            // Act
            PasswordManager.Delete(id);

            var amazonPasswordEntry = PasswordManager.GetEntry("Amazon");

            // Assert
            Assert.AreEqual(null, amazonPasswordEntry);
        }

        [Test]
        public void Update_ValidPasswordUpdate()
        {
            // Arrange
            PasswordManager.Add(GoodPassword);

            // Act
            GoodPassword.UserName = "jdavis@gmail.com";
            GoodPassword.Password = "BetterPassW0rd!";
            GoodPassword.SiteName = "Nothing";
            GoodPassword.Url = "https://www.Nothing.com";

            var result = PasswordManager.Update(GoodPassword);

            // Assert
            Assert.IsTrue(result.Contains(PasswordResult.Valid));
        }

        [Test]
        public void Update_ValidPasswordUpdateDataChangedCorrectly()
        {
            // Arrange
            PasswordManager.Add(GoodPassword);
            var result = false;

            // Act
            GoodPassword.UserName = "jdavis@gmail.com";
            GoodPassword.Password = "BetterPassW0rd!";
            GoodPassword.SiteName = "Nothing";
            GoodPassword.Url = "https://www.Nothing.com";

            PasswordManager.Update(GoodPassword);

            if (GoodPassword.UserName == "jdavis@gmail.com" && GoodPassword.Password == "BetterPassW0rd!" &&
                GoodPassword.SiteName == "Nothing" && GoodPassword.Url == "https://www.Nothing.com")
                result = true;

            // Assert
            Assert.IsTrue(result);
        }
    }
}

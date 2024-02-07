using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MoqClassDemo.Logic;
using MoqClassDemo.Models;
using MoqClassDemo.Services;
using NUnit.Framework;

namespace MoqClassDemo.Test
{
    public class PasswordManagerMoqTest : PasswordManagerTestBase
    {
        private readonly Mock<IDataStore> _mockDataStore = new();
        private readonly IList<PasswordEntry> _passwords = new List<PasswordEntry>();

        public PasswordManagerMoqTest() : base(new PasswordManager(null))
        {
            PasswordManager.DataStore = _mockDataStore.Object;

            _mockDataStore.Setup(dataStore => dataStore.Passwords)
                .Returns(_passwords);

            _mockDataStore.Setup(dataStore => dataStore.Add(It.IsAny<PasswordEntry>()))
                .Callback((PasswordEntry passwordEntry) =>
                {
                    _passwords.Add(passwordEntry);
                });

            _mockDataStore.Setup(dataStore => dataStore.Get(It.IsAny<string>()))
                .Returns((string siteName) =>
                {
                    return _passwords.SingleOrDefault(passwordEntry => passwordEntry.SiteName.Equals(siteName));
                });

            _mockDataStore.Setup(dataStore => dataStore.GetAll())
                .Returns(_passwords);

        }

        [Test]
        public void ZAddPasswordEntry_ShouldAddValidPassword()
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
    }
}

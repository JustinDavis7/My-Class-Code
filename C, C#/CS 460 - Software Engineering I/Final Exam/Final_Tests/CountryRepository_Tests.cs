using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using Final.DAL;
using Final.Models;
using Castle.Core.Logging;

namespace Final_Tests
{
    
    public class CountryRepository_Tests
    {
        private Mock<WCDbContext> _mockContext;
        private Mock<DbSet<Country>> _mockCountryDbSet;
        private List<Country> _countries;
        private List<Player> _players;
        private List<Position> _positions;


        [SetUp]
        public void Setup()
        {
            _positions = new List<Position>
            {
                new Position {Id = 4, Name = "Goalkeeper" },
                new Position {Id = 1, Name = "Defender" },
                new Position {Id = 3, Name = "Midfielder" },
                new Position {Id = 2, Name = "Forward" }
            };

            _countries = new List<Country>
            {
                new Country {Id = 1, FullName = "Argentina", Abbreviation = "ARG"},
                new Country {Id = 2, FullName = "Australia", Abbreviation = "AUS"},
                new Country {Id = 3, FullName = "Belgium", Abbreviation = "BEL"}
            };

            _players = new List<Player>
            {
                // ARG
                new Player {Id = 1, FullName = "Lionel Messi", CountryId = 1, PositionId = 2},
                new Player {Id = 2, FullName = "Ángel Di María", CountryId = 1, PositionId = 3},
                new Player {Id = 3, FullName = "Franco Armani", CountryId = 1, PositionId = 4},
                new Player {Id = 4, FullName = "Cristian Romero", CountryId = 1, PositionId = 1},
                new Player {Id = 5, FullName = "Rodrigo De Paul", CountryId = 1, PositionId = 3},
                new Player {Id = 6, FullName = "Germán Pezzella", CountryId = 1, PositionId = 1},
                // AUS
                new Player {Id = 7, FullName = "Nathaniel Atkinson", CountryId = 2, PositionId = 1}
            };
            _countries.ForEach(c =>
            {
                c.Players = _players.Where(p => p.CountryId == c.Id).ToList();
            });
            _players.ForEach(p =>
            {
                p.Position = _positions.Single(pos => p.PositionId == pos.Id);
            });
            _mockContext = new Mock<WCDbContext>();
            _mockCountryDbSet = MockHelpers.GetMockDbSet(_countries.AsQueryable());
            _mockContext.Setup(ctx => ctx.Countries).Returns(_mockCountryDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Country>()).Returns(_mockCountryDbSet.Object);
        }

        [TestCase("ARG")]
        [TestCase("AUS")]
        [TestCase("BEL")]
        public void CountryExists_ActualCountry_ShouldReturnCountry(string countryAbbreviation)
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            // Assert
            Assert.That(countryRepository.CountryExists(countryAbbreviation),Is.Not.Null);

        }

        [TestCase("arg")]
        [TestCase("aUS")]
        [TestCase("BeL")]
        public void CountryExists_ActualCountry_ShouldReturnCountryRegardlessOfCase(string countryAbbreviation)
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            // Assert
            Assert.That(countryRepository.CountryExists(countryAbbreviation), Is.Not.Null);

        }

        [TestCase("DBP")]
        [TestCase("ZZZ")]
        [TestCase("KZQ")]
        public void CountryExists_InvalidCountry_ShouldReturnNull(string countryAbbreviation)
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            // Assert
            Assert.That(countryRepository.CountryExists(countryAbbreviation), Is.Null);

        }

        [Test]
        public void GetPositionPlayers_NullCountry_ShouldThrow_ArgumentNullException()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = null!;

            // Assert
            Assert.That(() => countryRepository.GetPositionPlayers(country, "Goalkeeper"), Throws.ArgumentNullException);
        }

        [Test]
        public void GetPositionPlayers_NullPosition_ShouldThrow_ArgumentNullException()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string position = null!;

            // Assert
            Assert.That(() => countryRepository.GetPositionPlayers("ARG", position), Throws.ArgumentNullException);
        }

        [Test]
        public void GetPositionPlayers_ForGoalKeepersFromARG_ShouldReturnKeepersFromARG()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "ARG";
            string position = "Goalkeeper";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);
            List<Player> expectedPlayers = new List<Player>
            {
                _players[2]
            };
            // Assert
            Assert.That(actualPlayers, Is.EqualTo(expectedPlayers));
        }

        [Test]
        public void GetPositionPlayers_ForGoalKeepersFromarg_ShouldReturnKeepersFromarg()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "arg";
            string position = "Goalkeeper";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);
            List<Player> expectedPlayers = new List<Player>
            {
                _players[2]
            };
            // Assert
            Assert.That(actualPlayers, Is.EqualTo(expectedPlayers));
        }

        [Test]
        public void GetPositionPlayers_ForMidfieldersFromARG_ShouldReturnMidfieldersFromARG()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "ARG";
            string position = "Midfielder";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);
            List<Player> expectedPlayers = new List<Player>
            {
                _players[1],
                _players[4]
            };
            // Assert
            Assert.That(actualPlayers, Is.EquivalentTo(expectedPlayers));
        }

        [Test]
        public void GetPositionPlayers_FormidfieldersFromarg_ShouldReturnMidfieldersFromarg()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "arg";
            string position = "midfielder";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);
            List<Player> expectedPlayers = new List<Player>
            {
                _players[1],
                _players[4]
            };
            // Assert
            Assert.That(actualPlayers, Is.EquivalentTo(expectedPlayers));
        }

        [Test]
        public void GetPositionPlayers_ShouldReturnSortedList()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "ARG";
            string position = "Defender";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);
            List<Player> expectedPlayers = new List<Player>
            {
                _players[3],
                _players[5]
            };
            // Assert
            Assert.That(actualPlayers, Is.EqualTo(expectedPlayers));
        }

        [Test]
        public void GetPositionPlayers_ForInvalidPosition_ShouldReturnEmptyList()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "ARG";
            string position = "Referee";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);
           
            // Assert
            Assert.That(actualPlayers, Is.Empty);
        }

        [Test]
        public void GetPositionPlayers_ForInvalidCountry_ShouldReturnEmptyList()
        {
            // Arrange
            ICountryRepository countryRepository = new CountryRepository(_mockContext.Object);

            // Act
            string country = "ZZZ";
            string position = "Forward";
            List<Player> actualPlayers = countryRepository.GetPositionPlayers(country, position);

            // Assert
            Assert.That(actualPlayers, Is.Empty);
        }
    }
}

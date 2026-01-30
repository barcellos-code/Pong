using Game;
using Microsoft.Extensions.DependencyInjection;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class GameTests
    {
        [TestMethod]
        public void TestGameWidth()
        {
            // Arrange
            var gameParameters = GameContainer.Provider.GetService<IGameParameters>();
            var expectedWidth = gameParameters.Width;
            var game = GameContainer.Provider.GetService<IGame>();

            // Act
            game.Create(gameParameters);
            var actualWidth = game.Bounds.Width;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void TestGameHeight()
        {
            // Arrange
            var gameParameters = GameContainer.Provider.GetService<IGameParameters>();
            var expectedHeight = gameParameters.Height;
            var game = GameContainer.Provider.GetService<IGame>();

            // Act
            game.Create(gameParameters);
            var actualHeight = game.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            var gameParameters = GameContainer.Provider.GetService<IGameParameters>();
            var expectedNumberOfPlayers = gameParameters.NumberOfPlayers;
            var game = GameContainer.Provider.GetService<IGame>();

            // Act
            game.Create(gameParameters);
            var actualNumberOfPlayers = game.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);
        }
    }
}

using Game;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class PaddleTests
    {
        [TestMethod]
        public void TestNumberOfPaddles()
        {
            // Arrange
            var gameParameters = GameContainer.Provider.GetService<IGameParameters>();
            var expectedNumberOfPaddles = gameParameters.NumberOfPlayers;
            var game = GameContainer.Provider.GetService<IGame>();
            var paddlesManager = GameContainer.Provider.GetService<IPaddlesManager>();

            // Act
            game.Create(gameParameters);
            paddlesManager.CreatePaddles(game);
            var actualNumberOfPaddles = paddlesManager.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);
        }
    }
}

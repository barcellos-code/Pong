using GameStage;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;
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
            var playersParameters = GameContainer.Provider.GetService<IPlayersParameters>();
            var expectedNumberOfPaddles = playersParameters.NumberOfPlayers;
            var paddlesManager = GameContainer.Provider.GetService<IPaddlesManager>();

            // Act
            paddlesManager.CreatePaddles(playersParameters);
            var actualNumberOfPaddles = paddlesManager.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);
        }
    }
}

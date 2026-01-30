using Microsoft.Extensions.DependencyInjection;
using Players;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class PlayersTests
    {
        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            var playersParameters = GameContainer.Provider.GetService<IPlayersParameters>();
            var expectedNumberOfPlayers = playersParameters.NumberOfPlayers;
            var playersManager = GameContainer.Provider.GetService<IPlayersManager>();

            // Act
            playersManager.Create(playersParameters);
            var actualNumberOfPlayers = playersManager.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);
        }
    }
}

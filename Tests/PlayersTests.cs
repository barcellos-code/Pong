using Microsoft.Extensions.DependencyInjection;
using Players;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class PlayersTests
    {
        private static IPlayersManager? _playersManager;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _playersManager = GameContainer.Provider.GetService<IPlayersManager>();
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            var expectedNumberOfPlayers = 0;

            // Act
            _playersManager?.Create(expectedNumberOfPlayers);
            var actualNumberOfPlayers = _playersManager?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersManager?.Dispose();
            expectedNumberOfPlayers = 1;

            // Act
            _playersManager?.Create(expectedNumberOfPlayers);
            actualNumberOfPlayers = _playersManager?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersManager?.Dispose();
            expectedNumberOfPlayers = 2;

            // Act
            _playersManager?.Create(expectedNumberOfPlayers);
            actualNumberOfPlayers = _playersManager?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersManager?.Dispose();
            expectedNumberOfPlayers = 5;

            // Act
            _playersManager?.Create(expectedNumberOfPlayers);
            actualNumberOfPlayers = _playersManager?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Players;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class PlayersTests
    {
        private static IPlayersService? _playersService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _playersService = GameContainer.Provider.GetService<IPlayersService>();
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            var expectedNumberOfPlayers = 0;

            // Act
            _playersService?.CreatePlayers(expectedNumberOfPlayers);
            var actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            expectedNumberOfPlayers = 1;

            // Act
            _playersService?.CreatePlayers(expectedNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            expectedNumberOfPlayers = 2;

            // Act
            _playersService?.CreatePlayers(expectedNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            expectedNumberOfPlayers = 5;

            // Act
            _playersService?.CreatePlayers(expectedNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);
        }
    }
}

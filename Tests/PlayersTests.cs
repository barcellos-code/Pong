using Microsoft.Extensions.DependencyInjection;
using Players;

namespace Tests
{
    [TestClass]
    public sealed class PlayersTests
    {
        private static IPlayersService? _playersService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _playersService = PlayersContainer.ServiceProvider.GetService<IPlayersService>();
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            _playersService?.Dispose();
            var inputNumberOfPlayers = 0;
            var expectedNumberOfPlayers = 0;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            var actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            inputNumberOfPlayers = 1;
            expectedNumberOfPlayers = 1;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            inputNumberOfPlayers = 2;
            expectedNumberOfPlayers = 2;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            inputNumberOfPlayers = 5;
            expectedNumberOfPlayers = 5;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);
        }
    }
}

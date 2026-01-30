using GameStage;
using Microsoft.Extensions.DependencyInjection;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class GameStageTests
    {
        private static IGameStage? _gameStage;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _gameStage = GameContainer.Provider.GetService<IGameStage>();
        }

        [TestMethod]
        public void TestGameStageSize()
        {
            // Arrange
            _gameStage?.Dispose();
            var expectedWidth = 0;
            var expectedHeight = 0;

            // Act
            _gameStage?.Create(expectedWidth, expectedHeight);
            var actualWidth = _gameStage?.Bounds.Width;
            var actualHeight = _gameStage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            _gameStage?.Dispose();
            expectedWidth = 292;
            expectedHeight = 15;

            // Act
            _gameStage?.Create(expectedWidth, expectedHeight);
            actualWidth = _gameStage?.Bounds.Width;
            actualHeight = _gameStage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            _gameStage?.Dispose();
            expectedWidth = 63;
            expectedHeight = 12;

            // Act
            _gameStage?.Create(expectedWidth, expectedHeight);
            actualWidth = _gameStage?.Bounds.Width;
            actualHeight = _gameStage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }
    }
}

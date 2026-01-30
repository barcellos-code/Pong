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
        public void TestGameStageWidth()
        {
            // Arrange
            var expectedWidth = 0;

            // Act
            _gameStage?.Create(expectedWidth, 50);
            var actualWidth = _gameStage?.Bounds.Width;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);

            // Arrange
            expectedWidth = 10;

            // Act
            _gameStage?.Create(expectedWidth, 50);
            actualWidth = _gameStage?.Bounds.Width;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);

            // Arrange
            expectedWidth = 100;

            // Act
            _gameStage?.Create(expectedWidth, 50);
            actualWidth = _gameStage?.Bounds.Width;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void TestGameStageHeight()
        {
            // Arrange
            var expectedHeight = 0;

            // Act
            _gameStage?.Create(50, expectedHeight);
            var actualHeight = _gameStage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            expectedHeight = 10;

            // Act
            _gameStage?.Create(50, expectedHeight);
            actualHeight = _gameStage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            expectedHeight = 100;

            // Act
            _gameStage?.Create(50, expectedHeight);
            actualHeight = _gameStage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedHeight, actualHeight);
        }
    }
}

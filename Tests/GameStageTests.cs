using GameStage;
using Microsoft.Extensions.DependencyInjection;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class GameStageTests
    {
        [TestMethod]
        public void TestGameStageWidth()
        {
            // Arrange
            var gameStageParameters = GameContainer.Provider.GetService<IGameStageParameters>();
            var expectedWidth = gameStageParameters.Width;
            var stage = GameContainer.Provider.GetService<IGameStage>();

            // Act
            stage.Create(gameStageParameters);
            var actualWidth = stage.Bounds.Width;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void TestGameStageHeight()
        {
            // Arrange
            var gameStageParameters = GameContainer.Provider.GetService<IGameStageParameters>();
            var expectedHeight = gameStageParameters.Height;
            var stage = GameContainer.Provider.GetService<IGameStage>();

            // Act
            stage.Create(gameStageParameters);
            var actualHeight = stage.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedHeight, actualHeight);
        }
    }
}

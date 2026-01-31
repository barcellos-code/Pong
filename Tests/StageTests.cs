using Microsoft.Extensions.DependencyInjection;
using Pong;
using Stage;

namespace Tests
{
    [TestClass]
    public sealed class StageTests
    {
        private static IStage? _stage;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _stage = GameContainer.Provider.GetService<IStage>();
        }

        [TestMethod]
        public void TestGameStageSize()
        {
            // Arrange
            _stage?.Dispose();
            var expectedWidth = 0;
            var expectedHeight = 0;

            // Act
            _stage?.Create(expectedWidth, expectedHeight);
            var actualWidth = _stage?.Bounds.Width;
            var actualHeight = _stage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            _stage?.Dispose();
            expectedWidth = 292;
            expectedHeight = 15;

            // Act
            _stage?.Create(expectedWidth, expectedHeight);
            actualWidth = _stage?.Bounds.Width;
            actualHeight = _stage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            _stage?.Dispose();
            expectedWidth = 63;
            expectedHeight = 12;

            // Act
            _stage?.Create(expectedWidth, expectedHeight);
            actualWidth = _stage?.Bounds.Width;
            actualHeight = _stage?.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }
    }
}

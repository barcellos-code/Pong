using Ball;
using Microsoft.Extensions.DependencyInjection;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class BallTests
    {
        private static IBallService? _ballService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _ballService = GameContainer.Provider.GetService<IBallService>();
        }

        [TestMethod]
        public void TestBallPlacement()
        {
            // Arrange
            var stageWidth = 3;
            var stageHeight = 3;
            var expectedBallPosX = 1;
            var expectedBallPosY = 1;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight);
            var ball = _ballService?.GetBall();
            var actualBallPosX = ball?.PositionX;
            var actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 1;
            stageHeight = 1;
            expectedBallPosX = 0;
            expectedBallPosY = 0;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 5;
            stageHeight = 5;
            expectedBallPosX = 2;
            expectedBallPosY = 2;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 10;
            stageHeight = 10;
            expectedBallPosX = 5;
            expectedBallPosY = 5;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 30;
            stageHeight = 15;
            expectedBallPosX = 15;
            expectedBallPosY = 7;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);
        }
    }
}

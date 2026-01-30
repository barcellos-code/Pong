using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class PaddleTests
    {
        private static IPaddlesManager? _paddlesManager;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _paddlesManager = GameContainer.Provider.GetService<IPaddlesManager>();
        }

        [TestMethod]
        public void TestNumberOfPaddles()
        {
            // Arrange
            _paddlesManager?.Dispose();
            var expectedNumberOfPaddles = 0;

            // Assert
            Assert.Throws<InvalidOperationException>(() => _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10, stageHeight: 10));

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 1;

            // Assert
            Assert.Throws<InvalidOperationException>(() => _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10, stageHeight: 10));

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 2;

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10, stageHeight: 10);
            var actualNumberOfPaddles = _paddlesManager?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 5;

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10, stageHeight: 10);
            actualNumberOfPaddles = _paddlesManager?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);
        }

        [TestMethod]
        public void TestPaddleSize()
        {
            // Arrange
            _paddlesManager?.Dispose();
            var expectedPaddleSize = 0;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles: 2, expectedPaddleSize, stageWidth: 10, stageHeight: 10);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                Assert.AreEqual(expectedPaddleSize, paddle?.Size);
            }

            // Arrange
            _paddlesManager?.Dispose();
            expectedPaddleSize = 5;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles: 2, expectedPaddleSize, stageWidth: 10, stageHeight: 10);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                Assert.AreEqual(expectedPaddleSize, paddle?.Size);
            }

            // Arrange
            _paddlesManager?.Dispose();
            expectedPaddleSize = 10;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles: 2, expectedPaddleSize, stageWidth: 10, stageHeight: 10);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                Assert.AreEqual(expectedPaddleSize, paddle?.Size);
            }
        }

        [TestMethod]
        public void TestPaddlesHorizontalPositionOnCreation()
        {
            // Arrange
            _paddlesManager?.Dispose();
            var stageWidth = 10;
            var stageHeight = 10;
            var paddleSize = 2;
            var numberOfPaddles = 2;
            var firstPaddleExpectedXPos = 1;
            var secondPaddleExpectedXPos = 8;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

            // Assert
            Assert.AreEqual(_paddlesManager?.Get(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(1).PositionX, secondPaddleExpectedXPos);

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 50;
            stageHeight = 80;
            paddleSize = 5;
            numberOfPaddles = 2;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 48;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

            // Assert
            Assert.AreEqual(_paddlesManager?.Get(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(1).PositionX, secondPaddleExpectedXPos);

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 41;
            stageHeight = 20;
            paddleSize = 5;
            numberOfPaddles = 3;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 20;
            var thirdPaddleExpectedXPos = 39;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

            // Assert
            Assert.AreEqual(_paddlesManager?.Get(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(2).PositionX, thirdPaddleExpectedXPos);

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 40;
            stageHeight = 20;
            paddleSize = 5;
            numberOfPaddles = 3;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 19;
            thirdPaddleExpectedXPos = 38;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

            // Assert
            Assert.AreEqual(_paddlesManager?.Get(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(2).PositionX, thirdPaddleExpectedXPos);

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 41;
            stageHeight = 20;
            paddleSize = 5;
            numberOfPaddles = 5;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 10;
            thirdPaddleExpectedXPos = 19;
            var fourthPaddleExpectedXPos = 28;
            var fifthPaddleExpectedXPos = 39;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);

            // Assert
            Assert.AreEqual(_paddlesManager?.Get(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(2).PositionX, thirdPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(3).PositionX, fourthPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(4).PositionX, fifthPaddleExpectedXPos);
        }
    }
}

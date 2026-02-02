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
            Assert.Throws<InvalidOperationException>(() => _paddlesManager?
                .CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10,
                stageHeight: 10));

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 1;

            // Assert
            Assert.Throws<InvalidOperationException>(() => _paddlesManager?
                .CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10,
                stageHeight: 10));

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 2;

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5,
                stageWidth: 10, stageHeight: 10);
            var actualNumberOfPaddles = _paddlesManager?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 5;

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5,
                stageWidth: 10, stageHeight: 10);
            actualNumberOfPaddles = _paddlesManager?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);
        }

        [TestMethod]
        public void TestPaddleSize()
        {
            // Arrange
            _paddlesManager?.Dispose();
            var numberOfPaddles = 2;
            var stageWidth = 10;
            var stageHeight = 10;
            var inputSize = 0;
            var expectedPaddleSize = 0;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }

            // Arrange
            _paddlesManager?.Dispose();
            numberOfPaddles = 2;
            stageWidth = 10;
            stageHeight = 10;
            inputSize = 5;
            expectedPaddleSize = 5;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }

            // Arrange
            _paddlesManager?.Dispose();
            numberOfPaddles = 2;
            stageWidth = 10;
            stageHeight = 10;
            inputSize = 10;
            expectedPaddleSize = 10;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }

            // Arrange
            _paddlesManager?.Dispose();
            numberOfPaddles = 2;
            stageWidth = 10;
            stageHeight = 5;
            inputSize = 10;
            expectedPaddleSize = 5;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }
        }

        [TestMethod]
        public void TestPaddlesHorizontalPlacement()
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
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

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
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

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
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

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
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

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
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            Assert.AreEqual(_paddlesManager?.Get(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(2).PositionX, thirdPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(3).PositionX, fourthPaddleExpectedXPos);
            Assert.AreEqual(_paddlesManager?.Get(4).PositionX, fifthPaddleExpectedXPos);
        }

        [TestMethod]
        public void TestPaddlesVerticalPlacement()
        {
            // Arrange
            _paddlesManager?.Dispose();
            var stageWidth = 10;
            var stageHeight = 5;
            var numberOfPaddles = 2;
            var paddleSize = 1;
            var expectedPositionY = 2;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 10;
            stageHeight = 5;
            numberOfPaddles = 2;
            paddleSize = 3;
            expectedPositionY = 1;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 10;
            stageHeight = 5;
            numberOfPaddles = 2;
            paddleSize = 5;
            expectedPositionY = 0;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 10;
            stageHeight = 10;
            numberOfPaddles = 2;
            paddleSize = 3;
            expectedPositionY = 4;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 10;
            stageHeight = 10;
            numberOfPaddles = 2;
            paddleSize = 5;
            expectedPositionY = 3;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 10;
            stageHeight = 20;
            numberOfPaddles = 2;
            paddleSize = 5;
            expectedPositionY = 8;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesManager?.Dispose();
            stageWidth = 10;
            stageHeight = 20;
            numberOfPaddles = 2;
            paddleSize = 9;
            expectedPositionY = 6;

            // Act
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesManager?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }
        }

        [TestMethod]
        public void TestPaddlesMovement()
        {
            // Arrange
            _paddlesManager?.Dispose();
            var numberOfPaddles = 2;
            var paddleSize = 5;
            var stageWidth = 30;
            var stageHeight = 15;
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            var firstPaddle = _paddlesManager?.Get(0);
            var secondPaddle = _paddlesManager?.Get(1);
            var firstPaddleInitialPosY = firstPaddle?.PositionY;
            var secondPaddleInitialPosY = secondPaddle?.PositionY;
            var firstPaddleExpectedFinalPosY = firstPaddleInitialPosY + 1;
            var secondPaddleExpectedFinalPosY = secondPaddleInitialPosY - 1;

            // Act
            firstPaddle?.MoveUp();
            secondPaddle?.MoveDown();
            var firstPaddleActualFinalPosY = firstPaddle?.PositionY;
            var secondPaddleActualFinalPosY = secondPaddle?.PositionY;

            // Assert
            Assert.AreEqual(firstPaddleExpectedFinalPosY, firstPaddleActualFinalPosY);
            Assert.AreEqual(secondPaddleExpectedFinalPosY, secondPaddleActualFinalPosY);

            // Arrange
            _paddlesManager?.Dispose();
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            firstPaddle = _paddlesManager?.Get(0);
            secondPaddle = _paddlesManager?.Get(1);
            firstPaddleInitialPosY = firstPaddle?.PositionY;
            secondPaddleInitialPosY = secondPaddle?.PositionY;
            firstPaddleExpectedFinalPosY = firstPaddleInitialPosY - 1;
            secondPaddleExpectedFinalPosY = secondPaddleInitialPosY + 1;

            // Act
            firstPaddle?.MoveDown();
            secondPaddle?.MoveUp();
            firstPaddleActualFinalPosY = firstPaddle?.PositionY;
            secondPaddleActualFinalPosY = secondPaddle?.PositionY;

            // Assert
            Assert.AreEqual(firstPaddleExpectedFinalPosY, firstPaddleActualFinalPosY);
            Assert.AreEqual(secondPaddleExpectedFinalPosY, secondPaddleActualFinalPosY);

            // Arrange
            _paddlesManager?.Dispose();
            _paddlesManager?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            firstPaddle = _paddlesManager?.Get(0);
            secondPaddle = _paddlesManager?.Get(1);
            firstPaddleInitialPosY = firstPaddle?.PositionY;
            secondPaddleInitialPosY = secondPaddle?.PositionY;
            firstPaddleExpectedFinalPosY = 0;
            secondPaddleExpectedFinalPosY = 9;

            // Act
            for (var i = 0; i < 100; i++)
                firstPaddle?.MoveDown();
            for (var i = 0; i < 100; i++)
                secondPaddle?.MoveUp();
            firstPaddleActualFinalPosY = firstPaddle?.PositionY;
            secondPaddleActualFinalPosY = secondPaddle?.PositionY;

            // Assert
            Assert.AreEqual(firstPaddleExpectedFinalPosY, firstPaddleActualFinalPosY);
            Assert.AreEqual(secondPaddleExpectedFinalPosY, secondPaddleActualFinalPosY);
        }
    }
}

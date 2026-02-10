using Microsoft.Extensions.DependencyInjection;
using Paddles;

namespace EntitiesTests
{
    [TestClass]
    public sealed class PaddleTests
    {
        private static IPaddlesService? _paddlesService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _paddlesService = TestContainer.ServiceProvider.GetService<IPaddlesService>();
        }

        [TestMethod]
        public void TestNumberOfPaddles()
        {
            // Arrange
            _paddlesService?.Dispose();
            var expectedNumberOfPaddles = 0;

            // Assert
            Assert.Throws<InvalidOperationException>(() => _paddlesService?
                .CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10,
                stageHeight: 10));

            // Arrange
            _paddlesService?.Dispose();
            expectedNumberOfPaddles = 1;

            // Assert
            Assert.Throws<InvalidOperationException>(() => _paddlesService?
                .CreatePaddles(expectedNumberOfPaddles, paddleSize: 5, stageWidth: 10,
                stageHeight: 10));

            // Arrange
            _paddlesService?.Dispose();
            expectedNumberOfPaddles = 2;

            // Act
            _paddlesService?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5,
                stageWidth: 10, stageHeight: 10);
            var actualNumberOfPaddles = _paddlesService?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);

            // Arrange
            _paddlesService?.Dispose();
            expectedNumberOfPaddles = 5;

            // Act
            _paddlesService?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5,
                stageWidth: 10, stageHeight: 10);
            actualNumberOfPaddles = _paddlesService?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);
        }

        [TestMethod]
        public void TestPaddleSize()
        {
            // Arrange
            _paddlesService?.Dispose();
            var numberOfPaddles = 2;
            var stageWidth = 10;
            var stageHeight = 10;
            var inputSize = 0;
            var expectedPaddleSize = 0;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }

            // Arrange
            _paddlesService?.Dispose();
            numberOfPaddles = 2;
            stageWidth = 10;
            stageHeight = 10;
            inputSize = 5;
            expectedPaddleSize = 5;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }

            // Arrange
            _paddlesService?.Dispose();
            numberOfPaddles = 2;
            stageWidth = 10;
            stageHeight = 10;
            inputSize = 10;
            expectedPaddleSize = 10;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }

            // Arrange
            _paddlesService?.Dispose();
            numberOfPaddles = 2;
            stageWidth = 10;
            stageHeight = 5;
            inputSize = 10;
            expectedPaddleSize = 5;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, inputSize, stageWidth, stageHeight);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualSize = paddle?.Size;
                Assert.AreEqual(expectedPaddleSize, actualSize);
            }
        }

        [TestMethod]
        public void TestPaddlesHorizontalPlacement()
        {
            // Arrange
            _paddlesService?.Dispose();
            var stageWidth = 10;
            var stageHeight = 10;
            var paddleSize = 2;
            var numberOfPaddles = 2;
            var firstPaddleExpectedXPos = 1;
            var secondPaddleExpectedXPos = 8;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            Assert.AreEqual(_paddlesService?.GetPaddle(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(1).PositionX, secondPaddleExpectedXPos);

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 50;
            stageHeight = 80;
            paddleSize = 5;
            numberOfPaddles = 2;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 48;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            Assert.AreEqual(_paddlesService?.GetPaddle(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(1).PositionX, secondPaddleExpectedXPos);

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 41;
            stageHeight = 20;
            paddleSize = 5;
            numberOfPaddles = 3;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 20;
            var thirdPaddleExpectedXPos = 39;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            Assert.AreEqual(_paddlesService?.GetPaddle(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(2).PositionX, thirdPaddleExpectedXPos);

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 40;
            stageHeight = 20;
            paddleSize = 5;
            numberOfPaddles = 3;
            firstPaddleExpectedXPos = 1;
            secondPaddleExpectedXPos = 19;
            thirdPaddleExpectedXPos = 38;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            Assert.AreEqual(_paddlesService?.GetPaddle(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(2).PositionX, thirdPaddleExpectedXPos);

            // Arrange
            _paddlesService?.Dispose();
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
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            Assert.AreEqual(_paddlesService?.GetPaddle(0).PositionX, firstPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(1).PositionX, secondPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(2).PositionX, thirdPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(3).PositionX, fourthPaddleExpectedXPos);
            Assert.AreEqual(_paddlesService?.GetPaddle(4).PositionX, fifthPaddleExpectedXPos);
        }

        [TestMethod]
        public void TestPaddlesVerticalPlacement()
        {
            // Arrange
            _paddlesService?.Dispose();
            var stageWidth = 10;
            var stageHeight = 5;
            var numberOfPaddles = 2;
            var paddleSize = 1;
            var expectedPositionY = 2;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 10;
            stageHeight = 5;
            numberOfPaddles = 2;
            paddleSize = 3;
            expectedPositionY = 1;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 10;
            stageHeight = 5;
            numberOfPaddles = 2;
            paddleSize = 5;
            expectedPositionY = 0;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 10;
            stageHeight = 10;
            numberOfPaddles = 2;
            paddleSize = 3;
            expectedPositionY = 4;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 10;
            stageHeight = 10;
            numberOfPaddles = 2;
            paddleSize = 5;
            expectedPositionY = 3;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 10;
            stageHeight = 20;
            numberOfPaddles = 2;
            paddleSize = 5;
            expectedPositionY = 8;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }

            // Arrange
            _paddlesService?.Dispose();
            stageWidth = 10;
            stageHeight = 20;
            numberOfPaddles = 2;
            paddleSize = 9;
            expectedPositionY = 6;

            // Act
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth,
                stageHeight);

            // Assert
            for (var i = 0; i < _paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService?.GetPaddle(i);
                var actualPositionY = paddle?.PositionY;
                Assert.AreEqual(expectedPositionY, actualPositionY);
            }
        }

        [TestMethod]
        public void TestPaddlesMovement()
        {
            // Arrange
            _paddlesService?.Dispose();
            var numberOfPaddles = 2;
            var paddleSize = 5;
            var stageWidth = 30;
            var stageHeight = 15;
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            var firstPaddle = _paddlesService?.GetPaddle(0);
            var secondPaddle = _paddlesService?.GetPaddle(1);
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
            _paddlesService?.Dispose();
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            firstPaddle = _paddlesService?.GetPaddle(0);
            secondPaddle = _paddlesService?.GetPaddle(1);
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
            _paddlesService?.Dispose();
            _paddlesService?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            firstPaddle = _paddlesService?.GetPaddle(0);
            secondPaddle = _paddlesService?.GetPaddle(1);
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

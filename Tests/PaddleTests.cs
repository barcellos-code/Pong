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

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5);
            var actualNumberOfPaddles = _paddlesManager?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 2;

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5);
            actualNumberOfPaddles = _paddlesManager?.NumberOfPaddles;

            // Assert
            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);

            // Arrange
            _paddlesManager?.Dispose();
            expectedNumberOfPaddles = 5;

            // Act
            _paddlesManager?.CreatePaddles(expectedNumberOfPaddles, paddleSize: 5);
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
            _paddlesManager?.CreatePaddles(numberOfPaddles: 2, expectedPaddleSize);

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
            _paddlesManager?.CreatePaddles(numberOfPaddles: 2, expectedPaddleSize);

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
            _paddlesManager?.CreatePaddles(numberOfPaddles: 2, expectedPaddleSize);

            // Assert
            for (var i = 0; i < 2; i++)
            {
                var paddle = _paddlesManager?.Get(i);
                Assert.AreEqual(expectedPaddleSize, paddle?.Size);
            }
        }
    }
}

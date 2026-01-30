using Game;
using Microsoft.Extensions.DependencyInjection;
using Parameters;

namespace Tests
{
    [TestClass]
    public sealed class GameTests
    {
        private static IServiceProvider _provider;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IGame, PongGame>();
            collection.AddSingleton<IGameParameters, PongGameParameters>();
            _provider = collection.BuildServiceProvider();
        }

        [TestMethod]
        public void TestGameWidth()
        {
            // Arrange
            var gameParameters = _provider.GetService<IGameParameters>();
            var expectedWidth = gameParameters.Width;
            var game = _provider.GetService<IGame>();

            // Act
            game.Create(gameParameters);
            var actualWidth = game.Bounds.Width;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void TestGameHeight()
        {
            // Arrange
            var gameParameters = _provider.GetService<IGameParameters>();
            var expectedHeight = gameParameters.Height;
            var game = _provider.GetService<IGame>();

            // Act
            game.Create(gameParameters);
            var actualHeight = game.Bounds.Height;

            // Assert
            Assert.AreEqual(expectedHeight, actualHeight);
        }
    }
}

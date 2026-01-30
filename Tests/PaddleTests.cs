using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;
using Pong;

namespace Tests
{
    [TestClass]
    public sealed class PaddleTests
    {
        private static IPlayersParameters _playersParameters;
        private static IPaddlesParameters _paddlesParameters;
        private static IPaddlesManager _paddlesManager;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _playersParameters = GameContainer.Provider.GetService<IPlayersParameters>();
            _paddlesParameters = GameContainer.Provider.GetService<IPaddlesParameters>();
            _paddlesManager = GameContainer.Provider.GetService<IPaddlesManager>();
            _paddlesManager.CreatePaddles(_playersParameters, _paddlesParameters);
        }

        [TestMethod]
        public void TestNumberOfPaddles()
        {
            var expectedNumberOfPaddles = _playersParameters.NumberOfPlayers;
            var actualNumberOfPaddles = _paddlesManager.NumberOfPaddles;

            Assert.AreEqual(expectedNumberOfPaddles, actualNumberOfPaddles);
        }

        [TestMethod]
        public void TestPaddleSize()
        {
            var expectedPaddleSize = _paddlesParameters.PaddleSize;

            for (var i = 0; i < _playersParameters.NumberOfPlayers; i++)
            {
                var paddle = _paddlesManager.Get(i);
                Assert.AreEqual(expectedPaddleSize, paddle.Size);
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Stage;

namespace CoreTests
{
    [TestClass]
    public sealed class StageTests
    {
        private static IStageService? _stageService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        }

        [TestMethod]
        public void TestStageSize()
        {
            // Arrange
            _stageService?.Dispose();
            var inputWidth = 0;
            var inputHeight = 0;
            var expectedWidth = 0;
            var expectedHeight = 0;

            // Act
            _stageService?.CreateStage(inputWidth, inputHeight);
            var stage = _stageService?.GetStage();
            var actualWidth = stage?.Width;
            var actualHeight = stage?.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            _stageService?.Dispose();
            inputWidth = 292;
            inputHeight = 15;
            expectedWidth = 292;
            expectedHeight = 15;

            // Act
            _stageService?.CreateStage(inputWidth, inputHeight);
            stage = _stageService?.GetStage();
            actualWidth = stage?.Width;
            actualHeight = stage?.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);

            // Arrange
            _stageService?.Dispose();
            inputWidth = 63;
            inputHeight = 12;
            expectedWidth = 63;
            expectedHeight = 12;

            // Act
            _stageService?.CreateStage(inputWidth, inputHeight);
            stage = _stageService?.GetStage();
            actualWidth = stage?.Width;
            actualHeight = stage?.Height;

            // Assert
            Assert.AreEqual(expectedWidth, actualWidth);
            Assert.AreEqual(expectedHeight, actualHeight);
        }
    }
}

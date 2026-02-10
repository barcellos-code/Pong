using StageInteractor;

namespace StageController;

internal class StageController(IStageInteractor stageInteractor) : IStageController
{
    private readonly IStageInteractor _stageInteractor = stageInteractor;

    public void CreateStage(int width, int height)
        => _stageInteractor.CreateStage(width, height);
}

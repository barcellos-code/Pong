using Stage;

namespace StageInteractor;

internal class StageInteractor(IStageService stageService, IStagePresenter stagePresenter) : IStageInteractor
{
    private readonly IStageService _stageService = stageService;
    private readonly IStagePresenter _stagePresenter = stagePresenter;

    public void CreateStage(int width, int height)
    {
        _stageService.CreateStage(width, height);
        var stage = _stageService.GetStage();
        _stagePresenter.DrawStage(stage.Width, stage.Height);
    }
}

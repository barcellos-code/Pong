using StageInteractor;

namespace StagePresenter;

internal class StagePresenter(IStageView stageView) : IStagePresenter
{
    private readonly IStageView _stageVIew = stageView;

    public void DrawStage(int width, int height)
        => _stageVIew.DrawStage(width, height);
}

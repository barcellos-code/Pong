using UI;

namespace ConsoleUI;

public static partial class ViewFactory
{
    public static IStageView StageView()
        => new ConsoleStageView();
}

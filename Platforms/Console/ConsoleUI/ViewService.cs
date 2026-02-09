using UI;

namespace ConsoleUI;

internal class ViewService : IViewService
{
    private readonly List<IView> _views = [];

    public void Initialize()
    {
        Console.Title = "Console Pong";
        Console.CursorVisible = false;
    }

    public void AddView(IView view)
        => _views.Add(view);
    
    public void RemoveView(IView view)
        => _views.Remove(view);

    public void DrawAllViews()
        => _views.ForEach(view => view.Draw());
}

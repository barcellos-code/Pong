namespace UI;

public interface IViewService
{
    void Initialize();
    void AddView(IView view);
    void RemoveView(IView view);
    void DrawAllViews();
}

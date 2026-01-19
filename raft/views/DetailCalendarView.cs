using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class DetailCalendarView : IRaftView {
    private readonly Calendar _calendar = new Calendar(DateTime.Now);
    private Panel _panel { get; }

    public DetailCalendarView() {
        _panel = new Panel(_calendar).HeaderAlignment(Justify.Center).RoundedBorder().Expand();
    }

    public IRenderable Render() {
        return _panel;
    }
}
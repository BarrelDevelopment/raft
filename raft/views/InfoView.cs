using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class InfoView : IRaftView {
    private const string DUMMY_TEXT_LEFT = "Barrel";
    private const string DUMMY_TEXT_REIGHT = "2026";
    private Panel _panel { get; }
    public InfoView() {
        Panel panelLeft = new Panel(DUMMY_TEXT_LEFT).RoundedBorder();
        Panel panelRight = new Panel(DUMMY_TEXT_REIGHT).RoundedBorder();
        _panel = new Panel(
            new Columns(panelLeft, panelRight)
                .Padding(10, 0))
            .RoundedBorder()
            .Expand();
    }


    public IRenderable Render() {
        return _panel;
    }
}
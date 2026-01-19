using Spectre.Console;

namespace raft.views;

public class InfoView {
    private const string DUMMY_TEXT_LEFT = "Barrel";
    private const string DUMMY_TEXT_REIGHT = "2026";
    public Panel Panel { get; }
    public InfoView() {
        Panel panelLeft = new Panel(DUMMY_TEXT_LEFT).RoundedBorder();
        Panel panelRight = new Panel(DUMMY_TEXT_REIGHT).RoundedBorder();
        Panel = new Panel(
            new Columns(panelLeft, panelRight)
                .Padding(10, 0))
            .RoundedBorder()
            .Expand();
    }
}
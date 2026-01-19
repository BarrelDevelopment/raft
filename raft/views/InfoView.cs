using Spectre.Console;

namespace raft.views;

public class InfoView {

    private const int GIRD_COLUMNS = 2;
    
    private readonly Grid _grid = new Grid();
    public Grid Grid => _grid;

    public InfoView() {
        _grid.AddColumn(new GridColumn().Alignment(Justify.Left)).Expand();
        _grid.AddColumn(new GridColumn().Alignment(Justify.Right)).Expand();
        _grid.AddRow(new Markup("[green]Barrel[/]"), new Markup("[green]2026[/]"));
    }
}
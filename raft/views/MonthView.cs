using System.Globalization;
using Spectre.Console;

namespace raft.views;

public class MonthView {

    private const int GRID_COLUMNS = 3;
    private const int GRID_ROWS = 4;
    
    private readonly List<Panel> _panels = new List<Panel>();
    private readonly Grid _grid = new Grid().Expand();

    public MonthView() {
        for (int month = 1; month <= 12; month++) {
            _panels.Add(new Panel(CultureInfo.
                CurrentCulture.DateTimeFormat.
                GetAbbreviatedMonthName(month)).RoundedBorder());
        }

        //_grid.AddColumns(GRID_COLUMNS);
        for(int column = 0; column < GRID_COLUMNS; column++) _grid.AddColumn(new GridColumn().Width(30));
        for(int cnt = 0; cnt < GRID_ROWS; cnt++){
            // ReSharper disable once CoVariantArrayConversion
            _grid.AddRow(_panels.GetRange(cnt * GRID_COLUMNS, GRID_COLUMNS).ToArray());
        }
    }
    
    public Grid Grid => _grid;
}
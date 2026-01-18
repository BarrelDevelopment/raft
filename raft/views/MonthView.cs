using System.Globalization;
using Spectre.Console;

namespace raft.views;

public class MonthView {
    
    private readonly List<Panel> _panels = new List<Panel>();
    private readonly Table _table = new Table().HideHeaders().Border(TableBorder.None);

    public MonthView() {
        for (int month = 1; month <= 12; month++) {
            _panels.Add(new Panel(CultureInfo.
                CurrentCulture.DateTimeFormat.
                GetAbbreviatedMonthName(month)).RoundedBorder());
        }
        
        _table.AddColumn(new TableColumn(string.Empty));
        _table.AddColumn(new TableColumn(string.Empty));
        _table.AddColumn(new TableColumn(string.Empty));
        
        for(int cnt = 0; cnt < 4; cnt++){
            _table.AddRow(_panels.GetRange(cnt * 3, 3).ToArray());
        }
    }
    
    public Table Table => _table;
}
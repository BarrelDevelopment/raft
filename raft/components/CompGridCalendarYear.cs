using Spectre.Console;
namespace raft.components;

public class CompGridCalendarYear {
    private const int GridColumns = 4; 
    private const int GridRows = 3;
    
    private List<Calendar> calendars = new List<Calendar>();
    
    public Grid CalendarGird { get; set; }
    
    public CompGridCalendarYear(int year) {
        
        CalendarGird = new Grid();
        CalendarGird.AddColumns(GridColumns);
        
        for (int cnt = 1; cnt <= 12; cnt++) {
            calendars.Add(new Calendar(year, cnt));
        }
        
        CalendarGird.AddRow(calendars[0], calendars[1], calendars[2], calendars[3]);
        CalendarGird.AddRow(calendars[4], calendars[5], calendars[6], calendars[7]);
        CalendarGird.AddRow(calendars[8], calendars[9], calendars[10], calendars[11]);
    }
}
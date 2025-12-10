using System.Globalization;
using Spectre.Console;
using Calendar = Spectre.Console.Calendar;

namespace raft.components;

public class CompGridCalendarYear {
    public int GridColumns { get; set; } = 4;
    public int GridRows { get; set; } = 3;
    public Grid CalendarGird { get; set; }
    
    private List<Calendar> calendars = new List<Calendar>();
    
    public CompGridCalendarYear(int year) {

        CalendarGird = new Grid();
        CalendarGird.AddColumns(GridColumns);
        
        for (int cnt = 1; cnt <= 12; cnt++) {
            calendars.Add(new Calendar(year, cnt){ Culture = CultureInfo.CurrentCulture });
        }

        CalendarGird.AddRow(calendars[0], calendars[1], calendars[2], calendars[3]);
        CalendarGird.AddRow(calendars[4], calendars[5], calendars[6], calendars[7]);
        CalendarGird.AddRow(calendars[8], calendars[9], calendars[10], calendars[11]);
    }

    public Grid MarkCalendar(int index, Style style) {
        calendars[index].BorderStyle = style;
        return CalendarGird;
    }
}
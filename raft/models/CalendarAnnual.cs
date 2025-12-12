using System.Globalization;
using Spectre.Console;
using Calendar = Spectre.Console.Calendar;

namespace raft.models;

public class CalendarAnnual {
    public int Year { get; set; } = DateTime.Now.Year;
    public Style? Style { get; set; }
    public int GridColumns { get; set; } = 4;
    public int GridRows { get; set; } = 3;
    public List<Calendar> calendars { get; set; } = new List<Calendar>();
    public CultureInfo Culture { get; set; }
    public CalendarEvent CurrentCursorEvent { get; set; } = new CalendarEvent(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
}
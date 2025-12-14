using System.Globalization;
using Spectre.Console;
using raft.widgets;

namespace raft.models;

public class CalendarAnnual {
    public int Year { get; set; } = DateTime.Now.Year;
    public Style? Style { get; set; }
    public int GridColumns { get; set; } = 4;
    public int GridRows { get; set; } = 3;
    public List<RaftCalendar> calendars { get; set; } = new();
    public CultureInfo Culture { get; set; }

    public CalendarEvent CurrentCursorEvent { get; set; } =
        new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
}
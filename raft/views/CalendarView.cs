using raft.extensions;
using raft.models;
using raft.widgets;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class CalendarView {
    public readonly Grid calendarGird = new();
    private readonly CalendarAnnual calendarModel;
    private RaftCalendar lastCalendar;

    private CalendarEvent lastEvent;

    public CalendarView(CalendarAnnual calendarModel) {
        this.calendarModel = calendarModel;

        calendarModel.calendars = Enumerable
            .Range(1, 12)
            .Select(month => new RaftCalendar(calendarModel.Year, month) {
                Culture = calendarModel.Culture,
                BorderStyle = calendarModel.Style ?? Style.Plain
            }).ToList();

        CreateGridByList();
    }

    private void CreateGridByList() {
        calendarGird.AddColumns(calendarModel.GridColumns);
        for (var rowCount = 0; rowCount < calendarModel.GridRows; rowCount++) {
            var skpiIndex = rowCount * calendarModel.GridColumns;
            calendarGird.AddRow(calendarModel.calendars
                .Skip(skpiIndex)
                .Take(calendarModel.GridColumns)
                .ToArray<IRenderable>());
        }
    }

    public void RenderCalendarCursor(CalendarEvent cursorEvent) {
        var cal = calendarModel.calendars.Find(calendar =>
            calendar.Year == cursorEvent.Year && calendar.Month == cursorEvent.Month);
        cal.AddCalendarEvent(cursorEvent.Year, cursorEvent.Month, cursorEvent.Day);
        cal.CalendarEvents.Remove(lastEvent);
        lastEvent = cal.CalendarEvents.First();
    }
}
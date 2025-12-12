using raft.models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class CalendarView {
    private readonly CalendarAnnual calendarModel;
    public readonly Grid calendarGird = new Grid();
    
    public CalendarView(CalendarAnnual calendarModel) {
        this.calendarModel = calendarModel;

        calendarModel.calendars = Enumerable
            .Range(1, 12)
            .Select(month => new Calendar(calendarModel.Year, month) {
                Culture = calendarModel.Culture,
                BorderStyle = calendarModel.Style ?? Style.Plain
            }).ToList();
        
        CreateGridByList();
    }

    private void CreateGridByList() {
        calendarGird.AddColumns(calendarModel.GridColumns);
        for (int rowCount = 0; rowCount < calendarModel.GridRows; rowCount++) {
            int skpiIndex = rowCount * calendarModel.GridColumns;
            calendarGird.AddRow(calendarModel.calendars
                .Skip(skpiIndex)
                .Take(calendarModel.GridColumns)
                .ToArray<IRenderable>());
        }
    }

    public void RenderCalendarCursor() {
        
    }
}
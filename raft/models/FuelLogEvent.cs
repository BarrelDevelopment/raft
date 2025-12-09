using Spectre.Console;

namespace raft.models;

public class FuelLogEvent {
    private CalendarEvent? calendarEvent;
    private FuelLogEntry? entry;

    public FuelLogEvent CreateFuelLogEvent(FuelLogEntry fuleLogEntry, DateTime time) {
        entry = fuleLogEntry;
        calendarEvent = new CalendarEvent(time.Year, time.Month, time.Day);
        return this;
    }
}
using raft.widgets;
using Spectre.Console;

namespace raft.extensions;

/// <summary>
/// Contains extension methods for <see cref="Calendar"/>.
/// </summary>
public static class RaftCalendarExtensions
{
    /// <summary>
    /// Adds a calendar event.
    /// </summary>
    /// <param name="calendar">The calendar to add the calendar event to.</param>
    /// <param name="date">The calendar event date.</param>
    /// <param name="customEventHighlightStyle">The calendar event custom highlight style.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar AddCalendarEvent(this RaftCalendar calendar, DateTime date, Style? customEventHighlightStyle = null)
    {
        return AddCalendarEvent(calendar, string.Empty, date.Year, date.Month, date.Day, customEventHighlightStyle);
    }

    /// <summary>
    /// Adds a calendar event.
    /// </summary>
    /// <param name="calendar">The calendar to add the calendar event to.</param>
    /// <param name="description">The calendar event description.</param>
    /// <param name="date">The calendar event date.</param>
    /// <param name="customEventHighlightStyle">The calendar event custom highlight style.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar AddCalendarEvent(this RaftCalendar calendar, string description, DateTime date, Style? customEventHighlightStyle = null)
    {
        return AddCalendarEvent(calendar, description, date.Year, date.Month, date.Day, customEventHighlightStyle);
    }

    /// <summary>
    /// Adds a calendar event.
    /// </summary>
    /// <param name="calendar">The calendar to add the calendar event to.</param>
    /// <param name="year">The year of the calendar event.</param>
    /// <param name="month">The month of the calendar event.</param>
    /// <param name="day">The day of the calendar event.</param>
    /// <param name="customEventHighlightStyle">The calendar event custom highlight style.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar AddCalendarEvent(this RaftCalendar calendar, int year, int month, int day, Style? customEventHighlightStyle = null)
    {
        return AddCalendarEvent(calendar, string.Empty, year, month, day, customEventHighlightStyle);
    }

    /// <summary>
    /// Adds a calendar event.
    /// </summary>
    /// <param name="calendar">The calendar.</param>
    /// <param name="description">The calendar event description.</param>
    /// <param name="year">The year of the calendar event.</param>
    /// <param name="month">The month of the calendar event.</param>
    /// <param name="day">The day of the calendar event.</param>
    /// <param name="customEventHighlightStyle">The calendar event custom highlight style.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar AddCalendarEvent(this RaftCalendar calendar, string description, int year, int month, int day, Style? customEventHighlightStyle = null)
    {
        if (calendar is null)
        {
            throw new ArgumentNullException(nameof(calendar));
        }

        calendar.CalendarEvents.Add(new CalendarEvent(description, year, month, day, customEventHighlightStyle));
        return calendar;
    }

    /// <summary>
    /// Sets the calendar's highlight <see cref="Style"/>.
    /// </summary>
    /// <param name="calendar">The calendar.</param>
    /// <param name="style">The default highlight style.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar HighlightStyle(this RaftCalendar calendar, Style? style)
    {
        if (calendar is null)
        {
            throw new ArgumentNullException(nameof(calendar));
        }

        calendar.HighlightStyle = style ?? Style.Plain;
        return calendar;
    }

    /// <summary>
    /// Sets the calendar's header <see cref="Style"/>.
    /// </summary>
    /// <param name="calendar">The calendar.</param>
    /// <param name="style">The header style.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar HeaderStyle(this RaftCalendar calendar, Style? style)
    {
        if (calendar is null)
        {
            throw new ArgumentNullException(nameof(calendar));
        }

        calendar.HeaderStyle = style ?? Style.Plain;
        return calendar;
    }

    /// <summary>
    /// Shows the calendar header.
    /// </summary>
    /// <param name="calendar">The calendar.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar ShowHeader(this RaftCalendar calendar)
    {
        if (calendar is null)
        {
            throw new ArgumentNullException(nameof(calendar));
        }

        calendar.ShowHeader = true;
        return calendar;
    }

    /// <summary>
    /// Hides the calendar header.
    /// </summary>
    /// <param name="calendar">The calendar.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static RaftCalendar HideHeader(this RaftCalendar calendar)
    {
        if (calendar is null)
        {
            throw new ArgumentNullException(nameof(calendar));
        }

        calendar.ShowHeader = false;
        return calendar;
    }
}
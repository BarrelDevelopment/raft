using raft.components;

namespace raft.Managers;

public static class UiManager {
    public static CompLayout MainLayout { get; private set; }
    public static CompGridCalendarYear CalendarYearGird { get; private set; }
    
    public static void Init() {
        MainLayout = new CompLayout();
        //TODO: Change to variable year
        CalendarYearGird = new CompGridCalendarYear(DateTime.Now.Year);
        
        MainLayout.UpdateContent(CompLayout.Section.calendar, CalendarYearGird.CalendarGird);
    }
    
}
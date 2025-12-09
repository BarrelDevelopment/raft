using raft.components;

namespace raft.Managers;

public static class UiManager {
    public static CompLayout? MainLayout { get; private set; }
    public static CompGridCalendarYear? CalendarYearGird { get; private set; }
    public static CompPanelShowControls? PanelShowControls { get; private set; }
    
    //TODO: Manny object creation and possible null reference in here.
    //What about dependency injection?
    public static void Init() {
        MainLayout = new CompLayout();
        PanelShowControls = new CompPanelShowControls();
        //TODO: Change to variable year
        CalendarYearGird = new CompGridCalendarYear(DateTime.Now.Year);
        
        MainLayout.UpdateContent(CompLayout.Section.calendar, CalendarYearGird.CalendarGird);
        MainLayout.UpdateContent(CompLayout.Section.controls, PanelShowControls.Panel);
    }
    
}
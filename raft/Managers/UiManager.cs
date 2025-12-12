using raft.models;
using raft.views;
using Spectre.Console;

namespace raft.Managers;

public class UiManager {
    // Implements all views but the model of each view in the app manager 
    public readonly LayoutView mainLayoutView;
    private readonly CalendarView calendarGridView;
    private readonly ControlView controlPanelView;
    
    public UiManager(AppSettings settings, AppManager appManager) {
        
        mainLayoutView = new LayoutView(settings);
        controlPanelView = new ControlView();
        calendarGridView = new CalendarView(appManager.CalendarModel);
        
        InitializeLayout();
    }

    private void InitializeLayout() {
        try {
            mainLayoutView.UpdateView(LayoutView.Section.calendar, calendarGridView.calendarGird);
            mainLayoutView.UpdateView(LayoutView.Section.controls, controlPanelView.Panel);
        }
        catch (NullReferenceException exception) {
            AnsiConsole.WriteException(exception);
        }
    }
    
    public void UpdateUi() {
        
    }

    
}
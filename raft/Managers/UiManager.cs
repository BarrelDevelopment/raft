using raft.models;
using raft.views;
using Spectre.Console;

namespace raft.Managers;

public class UiManager {
    // Implements all views but the model of each view in the app manager 
    public readonly LayoutView? mainLayoutView;
    private CalendarView? calendarGridView;
    private ControlView? controlPanelView;
    
    private AppSettings settings;
    private AppManager appManager;
    
    public UiManager(AppSettings settings, AppManager appManager) {
        this.settings = settings;
        this.appManager = appManager;
        
        mainLayoutView = new LayoutView(this.settings);
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
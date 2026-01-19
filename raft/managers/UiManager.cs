using raft.models;
using raft.views;
using Spectre.Console;

namespace raft.Managers;

public class UiManager {
    
    private readonly ControlView _controlPanelView;
    private readonly MonthView _monthView;
    private readonly DetailCalendarView _detailCalendarView;
    private readonly InfoView _infoView;
    
    public readonly LayoutView _mainLayoutView;
    
    

    public UiManager(AppSettings settings, AppManager appManager) {
        _mainLayoutView = new LayoutView(settings);
        _controlPanelView = new ControlView();
        _monthView = new MonthView();
        _detailCalendarView = new DetailCalendarView();
        _infoView = new InfoView();
       

        InitializeLayout();
    }

    private void InitializeLayout() {
        try {
            _mainLayoutView.UpdateView(LayoutView.Section.monthly, _monthView.Panel);
            _mainLayoutView.UpdateView(LayoutView.Section.calendar, _detailCalendarView.Calendar);
            _mainLayoutView.UpdateView(LayoutView.Section.info, _infoView.Panel);
        }
        catch (NullReferenceException exception) {
            AnsiConsole.WriteException(exception);
        }
    }

    public void UpdateUi(LiveDisplayContext ctx) {
        ctx.Refresh();
    }
}
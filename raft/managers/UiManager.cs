using raft.models;
using raft.views;
using Spectre.Console;

namespace raft.Managers;

public class UiManager {
    
    private readonly ControlView _controlPanelView;
    public readonly LayoutView _mainLayoutView;

    public UiManager(AppSettings settings, AppManager appManager) {
        _mainLayoutView = new LayoutView(settings);
        _controlPanelView = new ControlView();
       

        InitializeLayout();
    }

    private void InitializeLayout() {
        try {
            //_mainLayoutView.UpdateView(LayoutView.Section.monthly, _calendarGridView.calendarGird);
            _mainLayoutView.UpdateView(LayoutView.Section.controls, _controlPanelView.Panel);
        }
        catch (NullReferenceException exception) {
            AnsiConsole.WriteException(exception);
        }
    }

    public void UpdateUi(LiveDisplayContext ctx) {
        ctx.Refresh();
    }
}
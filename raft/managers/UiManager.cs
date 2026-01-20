using raft.models;
using raft.views;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.Managers;

public class UiManager {

    

    private readonly Dictionary<LayoutView.Section, IRaftView> _sectionViews;
    
    public readonly LayoutView _mainLayoutView;
    
    public UiManager(AppSettings settings, AppManager appManager) {
        _mainLayoutView = new LayoutView(settings);
        
        _sectionViews = new Dictionary<LayoutView.Section, IRaftView> {
            { LayoutView.Section.monthly, new MonthView() },
            { LayoutView.Section.calendar, new DetailCalendarView() },
            { LayoutView.Section.info, new InfoView() },
            { LayoutView.Section.controls, new ControlView() },
            { LayoutView.Section.entryList, new EntryView() },
            { LayoutView.Section.statistics, new StatisticView() }
        };
        
        InitializeLayout();
    }

    private void InitializeLayout() {
        
        try {
            foreach(var view in _sectionViews) 
                _mainLayoutView.UpdateView(view.Key, view.Value.Render());
        }
        catch (NullReferenceException exception) {
            AnsiConsole.WriteException(exception);
        }
    }

    public void UpdateUi(LiveDisplayContext ctx) {
        ctx.Refresh();
    }
}
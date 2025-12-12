using raft.models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;
public class LayoutView {

    public enum Section {
        root, 
        calendar, 
        details, 
        statistics,
        controls
    }

    public int CalculatedCalendarLayoutSize { get; private set; }
    public int CalculatedMainLayoutSize { get; private set; }
    
    private readonly Dictionary<Section, string> sectionNames = new Dictionary<Section, string>() {
        { Section.root, "root" },
        { Section.calendar, "Calendar" },
        { Section.details, "Details" },
        { Section.statistics, "Statistics" },
        { Section.controls, "Controls" }
    };
    
    public Layout? Layout { get; set; }
    
    public LayoutView(AppSettings settings) {

        CalculatedCalendarLayoutSize = (int)Math.Floor(settings.ConsolenWidth / 10.0 * 7) - settings.MainLayoutPadding;
        CalculatedMainLayoutSize = (int)Math.Floor(settings.ConsolenWidth / 10.0 * 3) - settings.MainLayoutPadding;
        
        Layout = new Layout(sectionNames[Section.root])
            .SplitColumns(
                new Layout(sectionNames[Section.calendar])
                    .Ratio(2)
                    .Size(CalculatedCalendarLayoutSize),
                new Layout(sectionNames[Section.details])
                    .SplitRows(
                        new Layout(sectionNames[Section.statistics]),
                        new Layout(sectionNames[Section.controls])
                        ).Size(CalculatedMainLayoutSize));
    }

    public void UpdateView(Section section, IRenderable content) {
        Layout?[sectionNames[section]].Update(content);
    }
}
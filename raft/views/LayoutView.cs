using raft.models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class LayoutView {
    public enum Section {
        root,
        monthly,
        info,
        calendar,
        details,
        statistics,
        controls
    }

    private readonly Dictionary<Section, string> sectionNames = new() {
        { Section.root, "root" },
        { Section.monthly, "Monthly" },
        { Section.details, "Details" },
        { Section.statistics, "Statistics" },
        { Section.controls, "Controls" },
        { Section.info, "Info" },
        { Section.calendar, "Calendar" }
    };

    public LayoutView(AppSettings settings) {
        var partLeft = 7;
        var partRight = 3;
        
        if (settings.ShowInFullScreen) partLeft = 9;
        
        CalculatedCalendarLayoutSize =
            (int)Math.Floor(settings.ConsoleWidth / 10.0 * partLeft) - settings.MainLayoutPadding;
        CalculatedMainLayoutSize =
            (int)Math.Floor(settings.ConsoleWidth / 10.0 * partRight) - settings.MainLayoutPadding;

        Layout = new Layout(sectionNames[Section.root])
            .SplitColumns(
                new Layout(sectionNames[Section.monthly])
                    .Ratio(2)
                    .Size(CalculatedCalendarLayoutSize),
                new Layout(sectionNames[Section.details])
                    .SplitRows(
                        new Layout(sectionNames[Section.statistics]),
                        new Layout(sectionNames[Section.controls])
                    ).Size(CalculatedMainLayoutSize));

        if (settings.ShowInFullScreen)
            Layout[sectionNames[Section.details]].Invisible();
    }

    private int CalculatedCalendarLayoutSize { get; }
    private int CalculatedMainLayoutSize { get; }

    public Layout? Layout { get; set; }

    public void UpdateView(Section section, IRenderable content) {
        Layout?[sectionNames[section]].Update(content);
    }
}
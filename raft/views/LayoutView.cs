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

    private readonly Dictionary<Section, string> sectionNames = new() {
        { Section.root, "root" },
        { Section.calendar, "Calendar" },
        { Section.details, "Details" },
        { Section.statistics, "Statistics" },
        { Section.controls, "Controls" }
    };

    public LayoutView(AppSettings settings) {
        CalculatedCalendarLayoutSize = (int)Math.Floor(settings.ConsoleWidth / 10.0 * 7) - settings.MainLayoutPadding;
        CalculatedMainLayoutSize = (int)Math.Floor(settings.ConsoleWidth / 10.0 * 3) - settings.MainLayoutPadding;

        Layout = new Layout(sectionNames[Section.root])
            .SplitColumns(
                new Layout(sectionNames[Section.calendar])
                    .Ratio(2)
                    .Size(CalculatedCalendarLayoutSize),
                new Layout(sectionNames[Section.details]).Invisible()
                    .SplitRows(
                        new Layout(sectionNames[Section.statistics]),
                        new Layout(sectionNames[Section.controls])
                    ).Size(CalculatedMainLayoutSize));
    }

    private int CalculatedCalendarLayoutSize { get; }
    private int CalculatedMainLayoutSize { get; }

    public Layout? Layout { get; set; }

    public void UpdateView(Section section, IRenderable content) {
        Layout?[sectionNames[section]].Update(content);
    }
}
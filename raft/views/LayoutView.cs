using raft.models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class LayoutView {
    public enum Section {
        root,
        left,
        right,
        monthly,
        info,
        calendar,
        entryList,
        statistics,
        controls
    }

    private readonly Dictionary<Section, string> sectionNames = new() {
        { Section.root, "_root" },
        { Section.left, "_left" },
        { Section.right, "_right" },
        { Section.monthly, "Monthly" },
        { Section.entryList, "Details" },
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
                new Layout(sectionNames[Section.left]).SplitRows(
                        new Layout(sectionNames[Section.monthly])
                            .Ratio(10),
                        new Layout(sectionNames[Section.controls])),
                new Layout(sectionNames[Section.right]).SplitRows(
                        new Layout(sectionNames[Section.info])
                            .Ratio(3),
                        new Layout(sectionNames[Section.calendar]),
                        new Layout(sectionNames[Section.entryList]),
                        new Layout(sectionNames[Section.statistics])
                    ));

        
    }

    private int CalculatedCalendarLayoutSize { get; }
    private int CalculatedMainLayoutSize { get; }

    public Layout? Layout { get; set; }

    public void UpdateView(Section section, IRenderable content) {
        Layout?[sectionNames[section]].Update(content);
    }
}
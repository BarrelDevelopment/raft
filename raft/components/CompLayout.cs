using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.components;
public class CompLayout {

    public enum Section {
        root, 
        calendar, 
        details, 
        statistics,
        controls
    }

    private readonly Dictionary<Section, string> sectionNames = new Dictionary<Section, string>() {
        { Section.root, "root" },
        { Section.calendar, "Calendar" },
        { Section.details, "Details" },
        { Section.statistics, "Statistics" },
        { Section.controls, "Controls" }
    };
    
    public Layout? Layout { get; set; }
    
    public CompLayout() {
        Layout = new Layout(sectionNames[Section.root])
            .SplitColumns(
                new Layout(sectionNames[Section.calendar]), 
                new Layout(sectionNames[Section.details])
                    .SplitRows(
                        new Layout(sectionNames[Section.statistics]).Size(10),
                        new Layout(sectionNames[Section.controls]).Size(10)));
    }

    public void UpdateContent(Section section, IRenderable content) {
        Layout?[sectionNames[section]].Update(content);
    }
}
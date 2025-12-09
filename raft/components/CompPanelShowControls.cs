using Spectre.Console;

namespace raft.components;

//TODO: Will not be change anymore. Change to static?
//But how will it work with the ui manager? Are we fucked up?
public class CompPanelShowControls {
    public Panel? Panel { get; set; }

    // ReSharper disable once ConvertConstructorToMemberInitializers
    public CompPanelShowControls() {
        Panel = new Panel(new Text("Show controls here. The size of this panel will be changed as soon as I found out how this shit works").Centered()).Expand();
    }
}
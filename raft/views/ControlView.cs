using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

//TODO: Will not be change anymore. Change to static?
//But how will it work with the ui manager? Are we fucked up?
public class ControlView : IRaftView {

    private readonly Panel _panel;
    
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public ControlView() {
        _panel = new Panel(
            new Text(
                    "Show controls here. The size of this panel will be changed as soon as I found out how this shit works")
                .Centered()).Expand().Header("Controls").HeaderAlignment(
            Justify.Left);
    }

    
    public IRenderable Render() {
       return _panel;
    }
}
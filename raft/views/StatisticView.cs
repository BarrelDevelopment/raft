using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft.views;

public class StatisticView : IRaftView {
    public IRenderable Render() {
        return new Text(this.ToString()!);
    }
}
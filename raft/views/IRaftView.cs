using Spectre.Console.Rendering;

namespace raft.views;

public interface IRaftView {

    public IRenderable Render();
}
namespace raft.models;

using Spectre.Console;

public class AppSettings {
    public Profil? LastLoadedProfil { get; set; }
    public Style? MainBorderStyle { get; set; }
    public int ConsolenWidth { get; set; }
    public int ConsolenHeight { get; set; }
    public int MainLayoutPadding { get; set; }
}
using Spectre.Console;
using System.Text.Json;
using System.Text.Json.Serialization;
using raft.models;

namespace raft.managers;


public class SessionManager {
    public Profile CurrentProfile { get; private set; }
    private List<Profile> Profiles { get; set; } = new List<Profile>();

    private readonly AppSettings appSettings;

    public SessionManager(AppSettings appSettings) {
        this.appSettings = appSettings;
        Initialize();
    }

    private void Initialize() {
        if (string.IsNullOrEmpty(appSettings.PathToLastOpenedProfile)) {
            UiCreateNewProfile();
        }
    }

    private void UiCreateNewProfile() {
        AnsiConsole.MarkupLine($"Welcome to RAFT RAFT RAFT. Create a new profile:");
        var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");
        AnsiConsole.MarkupLine($"Hello, [blue]{name}[/]!");
        Profiles.Add( new Profile {
            Name = name
        } );
        AnsiConsole.MarkupLine($"Your profile has been created.");
        AnsiConsole.MarkupLine($"Press any key to continue...");
        Console.ReadKey();
    }
    
}
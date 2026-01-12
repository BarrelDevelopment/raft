using Newtonsoft.Json;
using Spectre.Console;
using raft.models;

namespace raft.managers;


public class SessionManager {
    public SessionProfile CurrentProfile { get; private set; }
    private SessionProfile lastModifiedProfile;
    
    //You can have more than one profile open in runtime. 
    //This session manager only saves the current profile. 
    //TODO: Save-All-Function or something like that
    private List<SessionProfile> Profiles { get; set; } = [];
    private readonly AppSettings appSettings;

    public SessionManager(AppSettings appSettings) {
        this.appSettings = appSettings;
        Initialize();
    }

    private void Initialize() {
        if (string.IsNullOrEmpty(appSettings.PathToLastOpenedProfile)) {
            UiCreateNewProfile();
            CurrentProfile = Profiles.First();
            SaveSessionProfile();
            appSettings.PathToLastOpenedProfile = CurrentProfile.FileSystemPath;
            return;
        }
        LoadSessionProfile();
    }

    private void SaveSessionProfile() {
        JsonSerializer serializer = new JsonSerializer {
            NullValueHandling = NullValueHandling.Ignore
        };
        CurrentProfile.FileSystemPath += "/RAFT-SessionProfile.json";
        using (StreamWriter sw = new StreamWriter(CurrentProfile.FileSystemPath))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, CurrentProfile);
        }

    }

    private void LoadSessionProfile() {
        Profiles.Add(
            JsonConvert.DeserializeObject<SessionProfile>(
                File.ReadAllText(appSettings.PathToLastOpenedProfile)) ?? throw new InvalidOperationException()
            );
    }

    private void UiCreateNewProfile() {
        AnsiConsole.MarkupLine($"Welcome to RAFT RAFT RAFT. Create a new profile:");
        var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");
        AnsiConsole.MarkupLine($"Hello, [blue]{name}[/]!");
        var path = AnsiConsole.Ask<string>("Where should your profile be stored?");
        AnsiConsole.MarkupLine($"Ok, we will save this profile to [blue]{path}[/]!");
        Profiles.Add( new SessionProfile {
            Name = name,
            FileSystemPath = path
        } );
        AnsiConsole.MarkupLine($"Your profile has been created.");
        AnsiConsole.MarkupLine($"Press any key to continue...");
        Console.ReadKey();
    }
    
}
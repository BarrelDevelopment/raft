using Newtonsoft.Json;
using Spectre.Console;
using raft.models;

namespace raft.managers;

public class SessionManager {
    private SessionProfile CurrentProfile { get; set; }
    private readonly AppSettings appSettings;

    public SessionManager(AppSettings appSettings) {
        this.appSettings = appSettings;
            
        if (!string.IsNullOrEmpty(appSettings.PathToLastOpenedProfile)) {
            CurrentProfile = LoadSessionProfile();
            return;
        }
        CurrentProfile = UiCreateNewProfile();
        SaveSessionProfile();
        appSettings.PathToLastOpenedProfile = CurrentProfile.FileStorageLocation;
    }

    private void SaveSessionProfile() {
        JsonSerializer serializer = new JsonSerializer {
            NullValueHandling = NullValueHandling.Ignore
        };
        var path = Path.Combine(CurrentProfile.FileStorageLocation, CurrentProfile.Name += ".json");
        using var sw = new StreamWriter(path);
        using var writer = new JsonTextWriter(sw);
        serializer.Serialize(writer, CurrentProfile);
    }

    private SessionProfile LoadSessionProfile() {
        return JsonConvert.DeserializeObject<SessionProfile>(
            File.ReadAllText(appSettings.PathToLastOpenedProfile)) ?? throw new InvalidOperationException();
    }

    //TODO: Move this to own view or something other. Don't keep it here
    private static SessionProfile UiCreateNewProfile() {
        AnsiConsole.Write(new FigletText("RAFT"));
        AnsiConsole.MarkupLine($"Welcome to RAFT RAFT RAFT. You have to create a new profile, so that we can sell your data to china:");
        var name = AnsiConsole.Ask<string>("What's your [green]name[/]?. This is not an expensive information, it is the name of the profile.");
        AnsiConsole.MarkupLine($"Hello, [blue]{name}[/]!");
        var path = AnsiConsole.Ask<string>("Where should your profile be stored? This can be the path where also your personal stuff is stored.");
        AnsiConsole.MarkupLine($"Ok, we will save this profile to [blue]{path}[/]!");
        AnsiConsole.MarkupLine($"Your profile has been created.");
        AnsiConsole.MarkupLine($"Press any key to continue...");
        Console.ReadKey();
        return new SessionProfile {  Name = name , FileStorageLocation = path };
    }
    
}
using Newtonsoft.Json;
using Spectre.Console;
using raft.models;

namespace raft.managers;

public class SessionManager {
    private SessionProfile CurrentProfile { get; set; }
    private readonly AppSettings appSettings;

    public SessionManager(AppSettings appSettings) {
        this.appSettings = appSettings;
            
        CurrentProfile = !string.IsNullOrEmpty(appSettings.PathToLastOpenedProfile) ? 
            LoadSessionProfile(appSettings.PathToLastOpenedProfile) : UiCreateNewProfile();
        
        appSettings.PathToLastOpenedProfile = SaveSessionProfile();
    }

    private string SaveSessionProfile() {
        JsonSerializer serializer = new JsonSerializer {
            NullValueHandling = NullValueHandling.Ignore
        };
        var path = Path.Combine(CurrentProfile.FileStorageLocation, CurrentProfile.Name);
        if(Path.GetExtension(path) != ".json") path += ".json";
        using var sw = new StreamWriter(path);
        using var writer = new JsonTextWriter(sw);
        serializer.Serialize(writer, CurrentProfile);
        return path;
    }

    private static SessionProfile LoadSessionProfile(string path) {
        if (!File.Exists(path)) {
            return UiOpenOrCreateSessionProfile();
        }
        return JsonConvert.DeserializeObject<SessionProfile>(
            File.ReadAllText(path)) ?? throw new InvalidOperationException();
    }
    
    //TODO: Move this to own view or something other. Don't keep it here
    private static SessionProfile UiOpenOrCreateSessionProfile() {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"Ähm hi, the last opened profile cannot be found anymore.");
        var askResult = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Would you like to open a profile or create a new profile?")
                .AddChoices("Open profile", "Create a new one", "I'm not sure"));

        switch (askResult) {
            case "Open profile":
                var path = AnsiConsole.Ask<string>("What is the path to your profile?");
                return LoadSessionProfile(path);
            case "Create a new one":
                return UiCreateNewProfile();
            case "I'm not sure":
                AnsiConsole.MarkupLine($"Oke. Hm. No worry. We just wait for your mom to show up and make some decisions");
                AnsiConsole.MarkupLine($"Let's try to exit the application for now...");
                Thread.Sleep(3000);
                AnsiConsole.MarkupLine("Okay?");
                Thread.Sleep(2500);
                AnsiConsole.MarkupLine("Goodbye");
                Thread.Sleep(1800);
                AnsiConsole.MarkupLine("Just kidding. Here is an exception:");
                Thread.Sleep(100);
                throw new ArgumentOutOfRangeException();
        }
        throw new InvalidOperationException();
    }
    
    
    private static SessionProfile UiCreateNewProfile() {
        AnsiConsole.Clear();
        AnsiConsole.Write(new FigletText("RAFT"));
        AnsiConsole.MarkupLine($"Welcome to RAFT RAFT RAFT. You have to create a new profile, so that we can sell your data to china:");
        var name = AnsiConsole.Ask<string>("What's your [green]name[/]?. This is not an expensive information, it is the name of the profile:");
        AnsiConsole.MarkupLine($"Hello, [blue]{name}[/]!");
        var path = AnsiConsole.Ask<string>("Where should your profile be stored? This can be the path where also your personal stuff is stored:");
        AnsiConsole.MarkupLine($"Ok, we will save this profile to [blue]{path}[/]!");
        AnsiConsole.MarkupLine($"Your profile has been created.");
        AnsiConsole.MarkupLine($"Press any key to continue...");
        Console.ReadKey();
        AnsiConsole.Clear();
        return new SessionProfile {  Name = name , FileStorageLocation = path };
    }
    
}
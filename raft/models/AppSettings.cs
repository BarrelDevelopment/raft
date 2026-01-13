using Newtonsoft.Json;

namespace raft.models;

public class AppSettings {
    public int ConsoleWidth { get; set; } = Console.WindowWidth;
    public int ConsoleHeight { get; set; } = Console.WindowHeight;
    public int MainLayoutPadding { get; set; } = 0;
    public bool ShowInFullScreen { get; set; } = true;
    public string PathToLastOpenedProfile { get; set; } = string.Empty;

    private const string appSettingsFile = $"raft/appsettings.json";
    private static readonly string applicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), appSettingsFile);
    
    public static void SaveAppSettings(AppSettings settings) {
        JsonSerializer serializer = new JsonSerializer {
            NullValueHandling = NullValueHandling.Ignore
        };
        
        FileInfo file = new FileInfo(applicationDataPath);
        if (!file.Directory!.Exists) Directory.CreateDirectory(file.Directory.FullName);
        
        using StreamWriter sw = new StreamWriter(applicationDataPath);
        using JsonWriter writer = new JsonTextWriter(sw);
        serializer.Serialize(writer, settings);
    }

    public static AppSettings LoadAppSettings() {
        if(!File.Exists(applicationDataPath)) return new AppSettings();
        return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(applicationDataPath))!;
    }
    
}
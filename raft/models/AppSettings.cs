using Newtonsoft.Json;

namespace raft.models;

public class AppSettings {
    public int ConsoleWidth { get; set; } = Console.WindowWidth;
    public int ConsoleHeight { get; set; } = Console.WindowHeight;
    public int MainLayoutPadding { get; set; } = 0;
    public bool ShowInFullScreen { get; set; } = true;
    public string PathToLastOpenedProfile { get; set; } = string.Empty;

    public static void SaveAppSettings(AppSettings settings) {
        JsonSerializer serializer = new JsonSerializer {
            NullValueHandling = NullValueHandling.Ignore
        };
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "raft.json");
        using StreamWriter sw = new StreamWriter(path);
        using JsonWriter writer = new JsonTextWriter(sw);
        serializer.Serialize(writer, settings);
    }

    public static AppSettings LoadAppSettings() {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "raft.json");
        if(!File.Exists(path)) return new AppSettings();
        return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(path))!;
    }
    
}
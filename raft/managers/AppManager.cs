using System.Globalization;
using System.Text.Json;
using raft.managers;
using raft.models;
using Spectre.Console;

namespace raft.Managers;

public class AppManager {
    private readonly UserInputManager userInputManager;
    private AppSettings Settings { get; }
    private UiManager UiManager { get; }
    
    private SessionManager SessionManager { get; }
     
    public CalendarAnnual CalendarModel { get; private set; } = new() {
        Year = DateTime.Now.Year, //TODO: not so suitable as wished. shit 
        //Culture = new CultureInfo("en-US")
        Culture = CultureInfo.CurrentCulture
    };
    public AppManager(AppSettings? settings = null) {
        settings ??= new AppSettings {
            ConsoleHeight = Console.WindowHeight,
            ConsoleWidth = Console.WindowWidth,
            MainLayoutPadding = 0,
            ShowInFullScreen = true
        };

        Settings = settings;
        UiManager = new UiManager(Settings, this);
        SessionManager = new SessionManager(Settings);
        userInputManager = new UserInputManager();
    }
   

    public void Run() {
        var isAppRunning = true;
        
        AnsiConsole.Live(UiManager.mainLayoutView.Layout)
            .Start(ctx => {
                while (isAppRunning) {
                    UiManager.UpdateUi(ctx);
                    isAppRunning = userInputManager.HandelUserInput();
                    
                }
            });
    }
}
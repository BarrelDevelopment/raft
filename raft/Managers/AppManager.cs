using System.Globalization;
using raft.models;
using Spectre.Console;

namespace raft.Managers;

public class AppManager {
    private AppSettings Settings { get; }
    private UiManager uiManager { get; }
    
    public CalendarAnnual CalendarModel { get; private set; } = new CalendarAnnual() {
        Year = DateTime.Now.Year, //TODO: not so suitable as wished. shit 
        Culture = CultureInfo.CurrentCulture,
    };

    private readonly UserInputManager? userInputManager;
    
    public AppManager(AppSettings? settings = null) {
        settings ??= new AppSettings() {
            ConsolenHeight = Console.WindowHeight,
            ConsolenWidth = Console.WindowWidth,
            MainLayoutPadding = 2,
        };
        
        Settings = settings;
        uiManager = new UiManager(Settings, this);
        userInputManager = new UserInputManager();
    }

    public void Run() {
        UserInputManager.InputType inputType = UserInputManager.InputType.None;
        bool running = true;
        
        AnsiConsole.Live(uiManager.mainLayoutView.Layout)
            .Start(ctx => {
                while (running) {
                    
                    ctx.Refresh();
                    inputType = userInputManager.GetUserInput();
                }
            });
    }
}
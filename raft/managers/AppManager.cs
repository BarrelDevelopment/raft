using System.Globalization;
using raft.models;
using Spectre.Console;

namespace raft.Managers;

public class AppManager {
    private readonly UserInputManager userInputManager;

    public AppManager(AppSettings? settings = null) {
        settings ??= new AppSettings {
            ConsoleHeight = Console.WindowHeight,
            ConsoleWidth = Console.WindowWidth,
            MainLayoutPadding = 2
        };

        Settings = settings;
        uiManager = new UiManager(Settings, this);
        userInputManager = new UserInputManager();
    }

    private AppSettings Settings { get; }
    private UiManager uiManager { get; }

    public CalendarAnnual CalendarModel { get; private set; } = new() {
        Year = DateTime.Now.Year, //TODO: not so suitable as wished. shit 
        Culture = CultureInfo.CurrentCulture
    };

    public void Run() {
        var isAppRunning = true;

        AnsiConsole.Live(uiManager.mainLayoutView.Layout)
            .Start(ctx => {
                while (isAppRunning) {
                    uiManager.UpdateUi(ctx);
                    isAppRunning = userInputManager.HandelUserInput();
                }
            });
    }
}
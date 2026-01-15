using System.Globalization;

using raft.commands;
using raft.managers;
using raft.models;

using Spectre.Console;

namespace raft.Managers;

public class AppManager {
    private readonly UserInputManager userInputManager;
    private AppSettings Settings { get; }
    private UiManager UiManager { get; }

    private SessionManager SessionManager { get; }

    private bool _isAppRunning;

    public CalendarAnnual CalendarModel { get; private set; } = new() {
        Year = DateTime.Now.Year, //TODO: not so suitable as wished. shit 
        //Culture = new CultureInfo("en-US")
        Culture = CultureInfo.CurrentCulture
    };

    public AppManager() {
        Settings = AppSettings.LoadAppSettings();
        UiManager = new UiManager(Settings, this);
        SessionManager = new SessionManager(Settings);
        userInputManager = new UserInputManager();
        userInputManager.CommandIssued += OnCommandIssued;
    }


    public void Run() {
        _isAppRunning = true;

        AnsiConsole.Live(UiManager.mainLayoutView.Layout)
            .Start(ctx => {
                while (_isAppRunning) {
                    UiManager.UpdateUi(ctx);
                    userInputManager.GetUserInput();
                }
                AppSettings.SaveAppSettings(Settings);
            });
    }

    private void OnCommandIssued(object? sender, IUserCommand command) {
        switch (command) {
            case NextCalendarDayCommand:
                NextCalendarDay();
                break;

            case NextCalendarMonthCommand:
                NextCalendarMonth();
                break;

            case SaveDataCommand:
                Save();
                break;

            case ExitCommand:
                Exit();
                break;
        }
    }
    private void NextCalendarDay() { }
    private void NextCalendarMonth() { }
    private void Save() { }

    private void Exit() {
        _isAppRunning = false;
    }
}
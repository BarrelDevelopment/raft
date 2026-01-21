using System.Globalization;

using raft.commands;
using raft.managers;
using raft.models;

using Spectre.Console;

namespace raft.Managers;

public class AppManager {
    private readonly UserInputManager _userInputManager;
    private readonly UiManager _uiManager;
    private readonly SessionManager _sessionManager;
    
    private readonly AppSettings _settings;
    private bool _isAppRunning;


    public AppManager() {
        _settings = AppSettings.LoadAppSettings();
        _uiManager = new UiManager(_settings, this);
        _sessionManager = new SessionManager(_settings);
        _userInputManager = new UserInputManager();
        _userInputManager.CommandIssued += OnCommandIssued;
    }


    public void Run() {
        _isAppRunning = true;

        AnsiConsole.Live(_uiManager._mainLayoutView.Layout!)
            .Start(ctx => {
                while (_isAppRunning) {
                    _uiManager.UpdateUi(ctx);
                    _userInputManager.GetUserInput();
                }
                AppSettings.SaveAppSettings(_settings);
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

    private void Save() {
        
    }

    private void Exit() {
        _isAppRunning = false;
    }
}
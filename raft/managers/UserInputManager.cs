using raft.commands;

namespace raft.managers;

public class UserInputManager {
    public event EventHandler<IUserCommand>? CommandIssued;

    public void GetUserInput() {
        Console.TreatControlCAsInput = true;

        var keyInfo = Console.ReadKey(true);
        var command = MapToCommand(keyInfo);

        if (command is not null)
            CommandIssued?.Invoke(this, command);
    }

    private IUserCommand? MapToCommand(ConsoleKeyInfo keyInfo) {
        var key = keyInfo.Key;
        var mod = keyInfo.Modifiers;

        if (mod.HasFlag(ConsoleModifiers.Control) && mod.HasFlag(ConsoleModifiers.Shift))
            return key switch {
                ConsoleKey.RightArrow => new NextCalendarYearCommand(),
                ConsoleKey.LeftArrow => new PreviousCalendarYearCommand(),
                _ => null
            };

        if (mod.HasFlag(ConsoleModifiers.Shift))
            return key switch {
                ConsoleKey.RightArrow => new NextCalendarMonthCommand(),
                ConsoleKey.LeftArrow => new PreviousCalendarMonthCommand(),
                ConsoleKey.UpArrow => new UpCalendarMonthCommand(),
                ConsoleKey.DownArrow => new DownCalendarMonthCommand(),
                _ => null
            };

        if (mod.HasFlag(ConsoleModifiers.Control))
            return key switch {
                ConsoleKey.S => new SaveDataCommand(),
                _ => null
            };

        if (mod.HasFlag(ConsoleModifiers.Alt))
            return key switch {
                ConsoleKey.M => new StatisticMonthCommand(),
                ConsoleKey.Y => new StatisticYearCommand(),
                ConsoleKey.P => new SwitchProfileCommand(),
                ConsoleKey.E => new EditProfileInfoCommand(),
                _ => null
            };

        return key switch {
            ConsoleKey.RightArrow => new NextCalendarDayCommand(),
            ConsoleKey.LeftArrow => new PreviousCalendarDayCommand(),
            ConsoleKey.UpArrow => new UpCalendarDayCommand(),
            ConsoleKey.DownArrow => new DownCalendarDayCommand(),
            ConsoleKey.Escape => new ExitCommand(),
            _ => null
        };
    }
}
namespace raft.commands;

// Kalender
public record NextCalendarDayCommand : IUserCommand;
public record NextCalendarMonthCommand : IUserCommand;
public record NextCalendarYearCommand : IUserCommand;

public record PreviousCalendarDayCommand : IUserCommand;
public record PreviousCalendarMonthCommand : IUserCommand;
public record PreviousCalendarYearCommand : IUserCommand;

public record UpCalendarDayCommand : IUserCommand;
public record UpCalendarMonthCommand : IUserCommand;
public record DownCalendarDayCommand : IUserCommand;
public record DownCalendarMonthCommand : IUserCommand;

// App
public record SaveDataCommand : IUserCommand;
public record ExitCommand : IUserCommand;

// Statistic and profile
public record StatisticMonthCommand : IUserCommand;
public record StatisticYearCommand : IUserCommand;
public record SwitchProfileCommand : IUserCommand;
public record EditProfileInfoCommand : IUserCommand;

public interface IUserCommand {
}
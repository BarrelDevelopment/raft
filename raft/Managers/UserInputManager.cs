namespace raft.Managers;

public class UserInputManager {
    public enum InputType {
        NextCalendarDay,            // RightArrow
        NextCalendarMonth,          // SHIFT+RightArrow
        NextCalendarYear,           // CTL+SHIFT+RightArrow
        PreviousCalendarDay,        // LeftArrow
        PreviousCalendarMonth,      // SHIFT+LeftArrow
        PreviousCalendarYear,       // CTL+SHIFT+LeftArrow
        DownCalendarDay,            // DownArrow
        DownCalendarMonth,          // SHIFT+UpDown
        UpCalendarDay,              // UpArrow
        UpCalendarMonth,            // SHIFT+UpArrow
        StatisticMonth,             // ALT+M
        StatisticYear,              // ALT+Y
        SwitchProfile,              // ALT+P
        EditProfileInfo,            // ALT+E
        SaveData,                   // CTL+S
        Exit,                       // ESC
        None
    }
    
    public InputType GetUserInput() {
        Console.TreatControlCAsInput = true;
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        ConsoleKey key = keyInfo.Key;
        ConsoleModifiers mod = keyInfo.Modifiers;

        if (mod.HasFlag(ConsoleModifiers.Control) && mod.HasFlag(ConsoleModifiers.Shift))
        {
            return key switch
            {
                ConsoleKey.RightArrow => InputType.NextCalendarYear,
                ConsoleKey.LeftArrow  => InputType.PreviousCalendarYear,
                _ => InputType.None
            };
        }

        if (mod.HasFlag(ConsoleModifiers.Shift))
        {
            return key switch
            {
                ConsoleKey.RightArrow => InputType.NextCalendarMonth,
                ConsoleKey.LeftArrow  => InputType.PreviousCalendarMonth,
                ConsoleKey.DownArrow  => InputType.DownCalendarMonth,
                ConsoleKey.UpArrow  => InputType.UpCalendarMonth,
                _ => InputType.None
            };
        }

        if (mod.HasFlag(ConsoleModifiers.Control))
        {
            return key switch
            {
                ConsoleKey.S => InputType.SaveData,
                _ => InputType.None
            };
        }

        if (mod.HasFlag(ConsoleModifiers.Alt))
        {
            return key switch
            {
                ConsoleKey.M => InputType.StatisticMonth,
                ConsoleKey.Y => InputType.StatisticYear,
                ConsoleKey.P => InputType.SwitchProfile,
                ConsoleKey.E => InputType.EditProfileInfo,
                _ => InputType.None
            };
        }

        return key switch
        {
            ConsoleKey.LeftArrow  => InputType.PreviousCalendarDay,
            ConsoleKey.RightArrow => InputType.NextCalendarDay,
            ConsoleKey.DownArrow  => InputType.DownCalendarDay,
            ConsoleKey.UpArrow    => InputType.UpCalendarDay,
            ConsoleKey.Escape     => InputType.Exit,
            _ => InputType.None
        };
    }
}
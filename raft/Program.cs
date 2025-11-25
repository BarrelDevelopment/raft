using Spectre.Console;

namespace raft;
// Welcome to RAFT RAFT RAFT (Redeem allowance and fuel tracker)
class Program {

    public static async Task Main(string[] args) {

        var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left"),
                new Layout("Right")
                    .SplitRows(
                        new Layout("Top"),
                        new Layout("Bottom")));


        var grid = new Grid();
        grid.AddColumns(2);

        var calender = new Calendar(2025, 11);
        var calender2 = new Calendar(2025, 12);
        grid.AddRow(calender);
        grid.AddRow(calender2);

        layout["Left"].Update(
            new Panel(grid)
                .Expand());


        int cnt = 1;
        //Now I add some comments
        AnsiConsole.MarkupLine("Press [yellow]CTRL+C[/] to exit");
        await AnsiConsole.Live(layout)
            .AutoClear(false)
            .Overflow(VerticalOverflow.Ellipsis)
            .Cropping(VerticalOverflowCropping.Bottom)
            .StartAsync(async ctx => {

                while (true) {
                    switch (Console.ReadKey(true).Key) {
                        case ConsoleKey.LeftArrow:
                            cnt--;
                            calender.CalendarEvents.RemoveAt(calender.CalendarEvents.Count - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            cnt++;
                            calender.AddCalendarEvent(2025, 11, cnt);
                            break;
                    }

                    if (cnt == 30) {
                        calender.CalendarEvents.Clear();
                        cnt = 1;
                    }
                    
                    

                    ctx.Refresh();
                    await Task.Delay(500);
                }
            });
    }
}
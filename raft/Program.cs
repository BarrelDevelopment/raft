using Spectre.Console;
using Spectre.Console.Rendering;

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

        int calendarColumns = 4;
        
        IRenderable[] calendars = new Calendar[12];
        Grid calendarGrid = new Grid().AddColumns(calendarColumns);
        for (int calenderCount = 0; calenderCount < 4; calenderCount++){
            for (int calendarRows = 0; calendarRows < 3; calendarRows++) {
                calendars[calendarRows] = new Calendar(2025, calenderCount * calendarColumns +1);
            }
            calendarGrid.AddRow(calendars);
        }

        var grid = new Grid().AddColumns(4);

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
                
                    ctx.Refresh();
                    await Task.Delay(500);
            });
    }
}


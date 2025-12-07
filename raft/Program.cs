using raft.components;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft;
// Welcome to RAFT RAFT RAFT (Redeem allowance and fuel tracker)
class Program {

    public static void Main(string[] args) {
        
        //TODO: Add check if the terminal is in a certain size. Inform 
        //user if not and force user to change size
        Console.SetWindowSize(500, 500);

        CompUserInput.InputType inputType = CompUserInput.InputType.None;
        CompLayout layout = new CompLayout();
        
        CompGridCalendarYear calendarYear = new CompGridCalendarYear(DateTime.Now.Year);

        if (layout.Layout == null) {
            throw new Exception("Layout is null");
        }

        CompUserInput userInput = new CompUserInput();
        
        AnsiConsole.Live(layout.Layout)
            .Start(ctx => {
                while (inputType != CompUserInput.InputType.Exit) {
                    inputType = userInput.ReadUserInput();
                    layout.UpdateContent(CompLayout.Section.statistics, new Panel(
                        Align.Center(
                            new Markup($"Your input [blue]{inputType}[/]"),
                            VerticalAlignment.Middle)));
                    layout.UpdateContent(CompLayout.Section.calendar, calendarYear.CalendarGird);
                    ctx.Refresh();
                }
            });
        
    }
}


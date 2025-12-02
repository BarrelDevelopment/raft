using raft.components;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace raft;
// Welcome to RAFT RAFT RAFT (Redeem allowance and fuel tracker)
class Program {

    public static void Main(string[] args) {
        string userInupt = String.Empty;
        CompLayout layout = new CompLayout();
        if (layout.Layout == null) {
            throw new Exception("Layout is null");
        }

        CompGridCalendarYear cl = new CompGridCalendarYear(2025);
        
        AnsiConsole.Write(cl.CalendarGird.Expand());
/*
 
        AnsiConsole.Live(layout.Layout)
            .Start(ctx => {
                while (userInupt != "e") {
                    userInupt = Console.ReadLine().ToLower();
                    layout.UpdateContent(CompLayout.Section.statistics, new Panel(
                        Align.Center(
                            new Markup($"Your input [blue]{userInupt}[/]"),
                            VerticalAlignment.Middle)).Expand());
                    ctx.Refresh();
                }
            });
        */
    }
}


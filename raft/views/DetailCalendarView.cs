using Spectre.Console;

namespace raft.views;

public class DetailCalendarView {
    private Calendar _calendar = new Calendar(DateTime.Now);
    
    public Calendar Calendar => _calendar;
    
    
}
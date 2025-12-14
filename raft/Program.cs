using raft.Managers;

namespace raft;

// Welcome to RAFT RAFT RAFT (Redeem allowance and fuel tracker)
internal class Program {
    public static void Main(string[] args) {
        //TODO: Add check if the terminal is in a certain size. Inform 
        //user if not and force user to change size
        Console.SetWindowSize(230, 35); //Works on Mac with 34" monitor 
        //TODO Maybe we can add pre calculated console sizes in the app settings

        var app = new AppManager();
        app.Run();
    }
}
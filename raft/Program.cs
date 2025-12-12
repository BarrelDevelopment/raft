using raft.Managers;

namespace raft;
// Welcome to RAFT RAFT RAFT (Redeem allowance and fuel tracker)
class Program {

    public static void Main(string[] args) {
        //TODO: Add check if the terminal is in a certain size. Inform 
        //user if not and force user to change size
        Console.SetWindowSize(230, 35);
        
        AppManager app = new AppManager();
        app.Run();
    }
}


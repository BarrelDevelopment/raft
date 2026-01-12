namespace raft.models;

public class SessionProfile {
    public string Name { get; set; }
    public List<FuelLogEntry> Entries { get; set; } = new List<FuelLogEntry>();
    
}
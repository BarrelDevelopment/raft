namespace raft.models;

public class SessionProfile {
    public string Name { get; set; } = string.Empty;
    public List<FuelLogEntry> Entries { get; set; } = [];
    public string FileStorageLocation { get; set; } = string.Empty;
    
}
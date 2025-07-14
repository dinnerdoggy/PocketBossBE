using PocketBoss.Models;

namespace PocketBoss;

public class Player
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string Name { get; set; }
    public bool IsHost { get; set; }
    public bool IsConnected { get; set; }
    public bool IsReady { get; set; }
    public string? ConnectionId { get; set; }

    // Navigation properties
    public int GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
    public int? ChosenMoveId { get; set; }
    public Move ChosenMove { get; set; }
    public int PCId { get; set; }
    public PC PC { get; set; }
}
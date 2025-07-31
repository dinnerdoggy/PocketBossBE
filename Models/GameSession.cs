namespace PocketBoss.Models;

public enum GameState
{
    Lobby,
    InProgress,
    Completed
}

public class GameSession
{
    public int Id { get; set; }
    public string? RoomCode { get; set; }
    public bool IsActive { get; set; } //May remove after getting comfortable using enums like GameState, as these two properties do overlap.
    public DateTime CreatedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public GameState GameState { get; set; }
    public int TurnNumber { get; set; }
}
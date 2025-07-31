namespace PocketBoss.Models;

public enum MoveType
{
    Attack,
    Heal,
    Buff,
    Debuff
}

public enum TargetType
{
    Self,
    Ally,
    AllAllies,
    Enemy,
    AllEnemies
}

public class Move
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public MoveType MoveType { get; set; }
    public TargetType TargetType { get; set; }
    public int Power { get; set; }

    // Navigation Properties
    public List<BossMove>? BossMoves { get; set; }
    public List<PCMove>? PCMoves { get; set; }
}
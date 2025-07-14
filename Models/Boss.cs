namespace PocketBoss.Models;

public class Boss
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    // Navigation Propery for join table
    public List<BossMove> BossMoves { get; set; }
}

public class BossMove
{
    public int BossId { get; set; }
    public Boss Boss { get; set; }

    public int MoveId { get; set; }
    public Move Move { get; set; }

    public int SlotNumber { get; set; }
}
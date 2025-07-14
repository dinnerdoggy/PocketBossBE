namespace PocketBoss.Models;

public class PC
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    // Navigation Propery for join table
    public List<PCMove> PCMoves { get; set; }
}

public class PCMove
{
    public int PCId { get; set; }
    public PC PC { get; set; }

    public int MoveId { get; set; }
    public Move Move { get; set; }

    public int SlotNumber { get; set; }
}
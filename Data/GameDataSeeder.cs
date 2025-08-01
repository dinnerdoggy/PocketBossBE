using PocketBoss.Models;

namespace PocketBoss.Data;

public class GameDataSeeder
{
    private readonly PocketBossDbContext _context;

    public GameDataSeeder(PocketBossDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        // === MOVES ===
        if (!_context.Moves.Any())
        {
            var moves = new List<Move>
            {
                new Move { Id = 1, Name = "Slash", Description = "A basic sword attack", Power = 25, MoveType = MoveType.Attack, TargetType = TargetType.Enemy },
                new Move { Id = 2, Name = "Heal", Description = "Restore an ally's HP", Power = 20, MoveType = MoveType.Heal, TargetType = TargetType.Ally },
                new Move { Id = 3, Name = "Shield Up", Description = "Raise your own defense", Power = 0, MoveType = MoveType.Buff, TargetType = TargetType.Self },
                new Move { Id = 4, Name = "Fireball", Description = "Launch a fireball at all enemies", Power = 15, MoveType = MoveType.Attack, TargetType = TargetType.AllEnemies },
                new Move { Id = 5, Name = "Weaken", Description = "Reduce an enemy's attack", Power = 0, MoveType = MoveType.Debuff, TargetType = TargetType.Enemy },
            };
            _context.Moves.AddRange(moves);
        }

        // === PCS ===
        if (!_context.PCs.Any())
        {
            var knight = new PC
            {
                Id = 1,
                Name = "Knight",
                Description = "A sturdy melee fighter with solid defense.",
                MaxHealth = 120,
                CurrentHealth = 120
            };

            var mage = new PC
            {
                Id = 2,
                Name = "Mage",
                Description = "A glass cannon with powerful spells.",
                MaxHealth = 80,
                CurrentHealth = 80
            };

            _context.PCs.AddRange(knight, mage);
        }

        // === PC MOVES ===
        if (!_context.PCMoves.Any())
        {
            var pcMoves = new List<PCMove>
            {
                // Knight
                new PCMove { PCId = 1, MoveId = 1, SlotNumber = 0 }, // Slash
                new PCMove { PCId = 1, MoveId = 3, SlotNumber = 1 }, // Shield Up

                // Mage
                new PCMove { PCId = 2, MoveId = 2, SlotNumber = 0 }, // Heal
                new PCMove { PCId = 2, MoveId = 4, SlotNumber = 1 }, // Fireball
            };
            _context.PCMoves.AddRange(pcMoves);
        }

        // === BOSSES ===
        if (!_context.Bosses.Any())
        {
            var boss = new Boss
            {
                Id = 1,
                Name = "Goblin King",
                Description = "A sneaky but dangerous foe leading a goblin horde.",
                MaxHealth = 200,
                CurrentHealth = 200
            };

            _context.Bosses.Add(boss);
        }

        // === BOSS MOVES ===
        if (!_context.BossMoves.Any())
        {
            var bossMoves = new List<BossMove>
            {
                new BossMove { BossId = 1, MoveId = 1, SlotNumber = 0 }, // Slash
                new BossMove { BossId = 1, MoveId = 5, SlotNumber = 1 }, // Weaken
                new BossMove { BossId = 1, MoveId = 4, SlotNumber = 2 }  // Fireball
            };
            _context.BossMoves.AddRange(bossMoves);
        }

        await _context.SaveChangesAsync();
    }
}

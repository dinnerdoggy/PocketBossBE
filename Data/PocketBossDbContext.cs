using PocketBoss.Models;
using Microsoft.EntityFrameworkCore;

namespace PocketBoss.Data;

public class PocketBossDbContext : DbContext
{
    public PocketBossDbContext(DbContextOptions<PocketBossDbContext> options) : base(options) { }

    public DbSet<GameSession> GameSessions { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PC> PCs { get; set; } 
    public DbSet<Boss> Bosses { get; set; }
    public DbSet<Move> Moves { get; set; }
    public DbSet<PCMove> PCMoves { get; set; }
    public DbSet<BossMove> BossMoves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GameSession>().HasData(
            new GameSession { 
                Id = 1, RoomCode = "abcd",
                IsActive = true,
                CreatedAt = new DateTime(2025, 07, 14),
                GameState = GameState.InProgress,
                TurnNumber = 1
            },

            new GameSession {
                Id = 2,
                RoomCode = "efgh",
                IsActive = true,
                CreatedAt = new DateTime(2025, 07, 14),
                GameState = GameState.InProgress,
                TurnNumber = 1
            }
        );

        modelBuilder.Entity<Player>().HasData(

            new Player
            {
                Id = 1,
                Uuid = "sample-uuid-1111",
                Name = "PlayerOne",
                IsHost = true,
                IsConnected = true,
                IsReady = false,
                ConnectionId = "AAA8kQq7tfdvdEr92dHXZg",
                GameSessionId = 1,
                ChosenMoveId = null,
                PCId = 1
            },

            new Player
            {
                Id = 2,
                Uuid = "sample-uuid-2222",
                Name = "PlayerTwo",
                IsHost = false,
                IsConnected = true,
                IsReady = false,
                ConnectionId = "BBB8kQq7tMZvdEr92dHXZg",
                GameSessionId = 1,
                ChosenMoveId = null,
                PCId = 2
            },

            new Player
            {
                Id = 3,
                Uuid = "sample-uuid-3333",
                Name = "PlayerThree",
                IsHost = false,
                IsConnected = true,
                IsReady = false,
                ConnectionId = "CCC8kQq7tMZvdEr92dHXZg",
                GameSessionId = 1,
                ChosenMoveId = null,
                PCId = 3
            },

            new Player
            {
                Id = 4,
                Uuid = "sample-uuid-4444",
                Name = "PlayerFour",
                IsHost = true,
                IsConnected = true,
                IsReady = false,
                ConnectionId = "DDDDkQq7tMZvdEr92dHXZg",
                GameSessionId = 2,
                ChosenMoveId = null,
                PCId = 4
            },

            new Player
            {
                Id = 5,
                Uuid = "sample-uuid-5555",
                Name = "PlayerFive",
                IsHost = false,
                IsConnected = true,
                IsReady = false,
                ConnectionId = "EEE8kQq7tMZvdEr92dHXZg",
                GameSessionId = 2,
                ChosenMoveId = null,
                PCId = 1
            }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC {
                Id = 1,
                Name = "Weapon Master",
                Description = "A fighter skilled in the use of weapons and trains in heavy armor",
                MaxHealth = 100,
                CurrentHealth = 100
            },

            new PC {
                Id = 2,
                Name = "Black Wizard",
                Description = "A wizard who's field of study is the magic involved with volitile reactions and entropy",
                MaxHealth = 80,
                CurrentHealth = 80
            },

            new PC {
                Id = 3,
                Name = "Rogue",
                Description = "A fighter who's martial focus is to cultivate elusiveness, identifying or creating, and striking weak points",
                MaxHealth = 90,
                CurrentHealth = 90
            },

            new PC {
                Id = 4,
                Name = "White Wizard",
                Description = "A wizard who's study focus is the magic involving the cultivation of life.",
                MaxHealth = 85,
                CurrentHealth = 85
            }
        );

        modelBuilder.Entity<Boss>().HasData(

            new Boss {
                Id = 1,
                Name = "Dreadlord",
                Description = "A necromantic terror thirsty for life force",
                MaxHealth = 500,
                CurrentHealth = 500
            }
        );

        modelBuilder.Entity<Move>().HasData(

            new Move {
                Id = 1,
                Name = "Slash",
                Description = "A basic melee attack.",
                MoveType = MoveType.Attack,
                TargetType = TargetType.Enemy,
                Power = 25
            },

            new Move {
                Id = 2,
                Name = "Fireball",
                Description = "A fiery ranged attack.",
                MoveType = MoveType.Attack,
                TargetType = TargetType.Enemy,
                Power = 30
            },

            new Move {
                Id = 3,
                Name = "Heal",
                Description = "Restore some health.",
                MoveType = MoveType.Heal,
                TargetType = TargetType.Ally,
                Power = 20
            }
        );

        modelBuilder.Entity<PCMove>().HasKey(pm => new { pm.PCId, pm.MoveId });

        modelBuilder.Entity<PCMove>().HasData(
            new PCMove {
                PCId = 1,
                MoveId = 1,
                SlotNumber = 1,
            },
            new PCMove {
                PCId = 2,
                MoveId = 2,
                SlotNumber = 2,
            },
            new PCMove {
                PCId = 4,
                MoveId = 3,
                SlotNumber = 3,
            }
        );

        modelBuilder.Entity<BossMove>().HasKey(bm => new { bm.BossId, bm.MoveId });

        modelBuilder.Entity<BossMove>().HasData(
            new BossMove
            {
                BossId = 1,
                MoveId = 1
            },
            new BossMove
            {
                BossId = 1,
                MoveId = 2
            }
        );
    }
}
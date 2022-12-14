using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
            Players = new HashSet<Player>();
        }
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }

        [StringLength(3)]
        public string Initials { get; set; }
        public decimal Budget { get; set; }
        //todo
        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }
        [InverseProperty(nameof(Game.HomeTeam))]
        public ICollection<Game> HomeGames { get; set; }

        [InverseProperty(nameof(Game.AwayTeam))]
        public ICollection<Game> AwayGames { get; set; }
        public ICollection<Player> Players { get; set; }


    }
}

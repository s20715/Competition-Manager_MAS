using CompetitionManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CompetitionManager.DAL
{
    public class CompetitionContext : DbContext
    {
        public CompetitionContext() : base("CompetitionContext")
        {
        }
        
        public DbSet<BagContribution> BagContributions { get; set; }
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        
        public DbSet<Game> Games { get; set; }
        
        public DbSet<Guest> Guests { get; set; }
        
        public DbSet<Helper> Helpers { get; set; }
        public DbSet<MainOrganizer> MainOrganizers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Rulebook> Rulebooks { get; set; }
        public DbSet<Team> Teams { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Captain>()
                        .HasRequired(s => s.Team)
                        .WithRequiredPrincipal(ad => ad.Captain);
        }
    }
}
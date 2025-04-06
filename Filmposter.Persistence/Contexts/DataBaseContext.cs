using Filmposter.Domain.Entities.Articles;
using Filmposter.Domain.Entities.Contact;
using Filmposter.Domain.Entities.Designs;
using Filmposter.Domain.Entities.Festival;
using Filmposter.Domain.Entities.FilmPosters;
using Filmposter.Domain.Entities.Users;
using FilmPoster.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Filmposter.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        // Guest Entities
        public DbSet<Newsletters> Newsletters { get; set; }

        // Admin Entities
        public DbSet<FilmPosters> FilmPosters { get; set; }
        public DbSet<FilmPosterScores> FilmPosterScores { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }
        public DbSet<ArticleComments> ArticleComments { get; set; }
        public DbSet<ArticleTags> ArticleTags { get; set; }
        public DbSet<FestivalJuries> FestivalJuries { get; set; }
        public DbSet<Festivals> Festivals { get; set; }
        public DbSet<FestivalSubmissionJudgments> FestivalSubmissionJudgments { get; set; }
        public DbSet<FestivalSubmissions> FestivalSubmissions { get; set; }
        public DbSet<Designs> Designs { get; set; }
        public DbSet<DesignFiles> DesignFiles { get; set; }

        // User Entities
        public DbSet<Users> Users { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<UserPayments> UserPayments { get; set; }
        public DbSet<UserPhoneEmailValidation> UserPhoneEmailValidation { get; set; }

        // Entities Configurations
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.HasDefaultSchema("dbo");
        //}
        // DbSet properties (unchanged, omitted for brevity)

        private void UpdateTimestamps()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                var inserted = entityType?.FindProperty("InsertDate");
                var updated = entityType?.FindProperty("UpdateDate");
                var deleted = entityType?.FindProperty("DeleteDate");

                switch (entry.State)
                {
                    case EntityState.Added:
                        if (inserted != null) entry.Property("InsertDate").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        if (updated != null) entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        if (deleted != null)
                        {
                            entry.Property("DeleteDate").CurrentValue = DateTime.Now;
                            entry.State = EntityState.Modified;
                        }
                        break;
                }
            }
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}

using Filmposter.Domain.Entities;
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

        // Admin Entities
        public DbSet<NationFilmPosters> NationFilmPosters { get; set; }

        // User Entities


        // Entities Configurations
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.HasDefaultSchema("dbo");
        //}
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries()
               .Where(e =>
                   e.State == EntityState.Modified ||
                   e.State == EntityState.Added ||
                   e.State == EntityState.Deleted
               ).ToList();

            foreach (var entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                var inserted = entityType.FindProperty("InsertDate");
                var updated = entityType.FindProperty("UpdateDate");
                var deleted = entityType.FindProperty("DeleteDate");

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

            // Ensure asynchronous call to the base SaveChangesAsync
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
           .Where(e =>
               e.State == EntityState.Modified ||
               e.State == EntityState.Added ||
               e.State == EntityState.Deleted
               ).ToList();
            foreach (var entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                var inserted = entityType.FindProperty("InsertDate");
                var updated = entityType.FindProperty("UpdateDate");
                var deleted = entityType.FindProperty("DeleteDate");
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
            return base.SaveChanges();
        }
    }

}

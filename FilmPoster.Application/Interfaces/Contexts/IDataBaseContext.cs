using Filmposter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmPoster.Application.Interfaces.Contexts
{
    public interface IDataBaseContext : IDisposable
    {
        DatabaseFacade Database { get; }

        // Guest Entities


        // Admin Entities
        DbSet<NationFilmPosters> NationFilmPosters { get; set; }

        // User Entities


        //SaveChanges
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

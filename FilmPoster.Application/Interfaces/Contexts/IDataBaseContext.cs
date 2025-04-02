using Filmposter.Domain.Entities.Articles;
using Filmposter.Domain.Entities.Contact;
using Filmposter.Domain.Entities.Designs;
using Filmposter.Domain.Entities.Festival;
using Filmposter.Domain.Entities.FilmPosters;
using Filmposter.Domain.Entities.Users;
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

        DbSet<Newsletters> Newsletters { get; set; }

        // Admin Entities
        DbSet<FilmPosters> FilmPosters { get; set; }
        DbSet<Articles> Articles { get; set; }
        DbSet<ArticleCategories> ArticleCategories { get; set; }
        DbSet<ArticleComments> ArticleComments { get; set; }
        DbSet<ArticleTags> ArticleTags { get; set; }
        DbSet<FestivalJuries> FestivalJuries { get; set; }
        DbSet<Festivals> Festivals { get; set; }
        DbSet<FestivalSubmissionJudgments> FestivalSubmissionJudgments { get; set; }
        DbSet<FestivalSubmissions> FestivalSubmissions { get; set; }
        DbSet<Designs> Designs { get; set; }
        DbSet<DesignFiles> DesignFiles { get; set; }

        // User Entities
        DbSet<Users> Users { get; set; }
        DbSet<UserLogs> UserLogs { get; set; }
        DbSet<UserPayments> UserPayments { get; set; }
        DbSet<UserPhoneEmailValidation> UserPhoneEmailValidation { get; set; }


        //SaveChanges
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

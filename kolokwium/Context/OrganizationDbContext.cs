using kolokwium.Model;
using Microsoft.EntityFrameworkCore;
using File = kolokwium.Model.File;

namespace kolokwium.Context;

public class OrganizationDbContext : DbContext
{
    public DbSet<Organization> Organization { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<File> File { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Membership> Membership { get; set; }

    public OrganizationDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>(e =>
        {
            e.HasKey(e => new
            {
                e.FileID, e.TeamID
            });
            
            e.HasData(
                new File
                {
                    FileID = 1,
                    TeamID = 1,
                    Name = "wynik",
                    Extension = ".txt",
                    Size = 3
                },
                new File
                {
                    FileID = 2,
                    TeamID = 1,
                    Name = "pismo",
                    Extension = ".docx",
                    Size = 10
                },
                new File
                {
                    FileID = 3,
                    TeamID = 2,
                    Name = "wniosek",
                    Extension = ".rar",
                    Size = 20
                }
            );
        });

        modelBuilder.Entity<Team>(e =>
        {
            e.HasData(
                new Team
                {
                    TeamID = 1,
                    OrganizationID = 1,
                    Name = "Niebiescy"
                },
                new Team
                {
                    TeamID = 2,
                    OrganizationID = 1,
                    Name = "Zieloni"
                },
                new Team
                {
                    TeamID = 3,
                    OrganizationID = 2,
                    Name = "Czerwoni",
                    Description = "Ten zespół jest czerwony"
                }
            );
        });

        modelBuilder.Entity<Organization>(e =>
        {
            e.HasData(
                new Organization
                {
                    OrganizationID = 1,
                    Name = "Kolorowi",
                    Domain = "Kolory"
                },
                new Organization
                {
                    OrganizationID = 2,
                    Name = "Jednostkowi",
                    Domain = "Jednostki"
                }
            );
        });

        modelBuilder.Entity<Member>(e =>
        {
            e.HasData(
                new Member
                {
                    MemberID = 1,
                    OrganizationID = 1,
                    Name = "Jan",
                    Surname = "Kowalski",
                    Nickname = "Kowal"
                },
                new Member
                {
                    MemberID = 2,
                    OrganizationID = 2,
                    Name = "Jakub",
                    Surname = "Nowak"
                },
                new Member
                {
                    MemberID = 3,
                    OrganizationID = 2,
                    Name = "Sławomir",
                    Surname = "XYZ",
                    Nickname = "Skrót"
                }
            );
        });

        modelBuilder.Entity<Membership>(e =>
        {
            e.HasKey(e => new
            {
                e.MemberID, e.TeamID
            });

            e.HasOne(ms => ms.Member).WithMany().OnDelete(DeleteBehavior.NoAction);
            e.HasOne(ms => ms.Team).WithMany().OnDelete(DeleteBehavior.NoAction);

            e.HasData(
                new Membership
                {
                    MemberID = 1,
                    TeamID = 1
                },
                new Membership
                {
                    MemberID = 2,
                    TeamID = 3
                },
                new Membership
                {
                    MemberID = 3,
                    TeamID = 3
                }
            );
        });
        
        base.OnModelCreating(modelBuilder);
    }
}

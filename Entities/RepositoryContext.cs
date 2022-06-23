using Microsoft.EntityFrameworkCore;
using probne_kolokwium.Entities.Models;

namespace probne_kolokwium.Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<File> File { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Member> Member { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(e =>
            {
                e.ToTable("File");
                e.HasKey(e => e.FileID);

                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileExtension).HasMaxLength(4).IsRequired();
                e.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new File
                    {
                        FileID = 1,
                        TeamID = 1,
                        FileName = "asdsda",
                        FileExtension = "png",
                        FileSize= 2
                        
                    }
                );
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.ToTable("Team");
                e.HasKey(e => e.TeamID);

                e.Property(e => e.TeamName).HasMaxLength(50).IsRequired();
                e.Property(e => e.TeamDescription).HasMaxLength(500).IsRequired();


                e.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new Team
                    {
                        TeamID = 1,
                        OrganizationID = 1,
                        TeamName = "teamnazwa",
                        TeamDescription= "opis",
                    }
                );;
            });

            modelBuilder.Entity<Member>(e =>
            {
                e.ToTable("Member");
                e.HasKey(e => e.MemberID);

                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(50);

                e.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new Member
                    {
                        MemberID = 1,
                        OrganizationID = 1,
                        MemberName = "Piter",
                        MemberSurname = "Pettigrew",
                        MemberNickName = "glizdogon"
                    }
                );
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.HasKey(e => new { e.MemberID, e.TeamID });
                e.Property(e => e.MembershipDate);

                e.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.ClientCascade);


                e.HasData(
                    new Membership
                    {
                        MemberID = 1,
                        TeamID = 1,

                        MembershipDate = new System.DateTime(2022,12,25)
                    }
                );

            });

            modelBuilder.Entity<Organization>(e =>
            {
                e.ToTable("Organization");
                e.HasKey(e => e.OrganizationID);

   
                e.Property(e => e.OrganizationName).HasMaxLength(300).IsRequired();
                e.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();

                e.HasData(
                    new Organization
                    {
                        OrganizationID = 1,
                        OrganizationName = "PwC",
                        OrganizationDomain = "Audit"
                    },
                    new Organization
                    {
                        OrganizationID = 2,
                        OrganizationName = "Deloitte",
                        OrganizationDomain = "Audit"
                    }
                );
            });
        }
    }
}

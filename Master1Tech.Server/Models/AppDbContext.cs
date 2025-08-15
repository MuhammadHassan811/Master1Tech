using Master1Tech.Models;
using Master1Tech.Services;
using Master1Tech.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Master1Tech.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Upload> Uploads => Set<Upload>();
        public DbSet<User> Users => Set<User>();

        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CompaniesCategory> CompanyCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<CompaniesService> CompanyServices { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<CompanyTechnology> CompanyTechnologies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<FirstAnswerQuestion> FirstAnswerQuestions { get; set; }
        public DbSet<CompanyIndustryFocus> CompanyIndustryFocuses { get; set; }
        public DbSet<GetInTouch> GetInTouches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite keys for many-to-many relationships
            modelBuilder.Entity<CompaniesCategory>()
                .HasKey(cc => new { cc.CompanyId, cc.CategoryId });

            modelBuilder.Entity<CompaniesService>()
                .HasKey(cs => new { cs.CompanyID, cs.ServiceID });

            modelBuilder.Entity<CompanyTechnology>()
                .HasKey(ct => new { ct.CompanyID, ct.TechnologyID });

            // Configure self-referencing relationship for Categories
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal precision for Review.Rating
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasColumnType("decimal(2,1)");

            // Configure decimal precision for Location coordinates
            modelBuilder.Entity<CompanyLocation>()
                .Property(l => l.Latitude)
                .HasColumnType("decimal(10,8)");

            modelBuilder.Entity<CompanyLocation>()
                .Property(l => l.Longitude)
                .HasColumnType("decimal(11,8)");
        }
    }
}
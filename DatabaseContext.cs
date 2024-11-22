using Microsoft.EntityFrameworkCore;

namespace CMCS.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Claim> Claims { get; set; } = default!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new User { UserId = 2, Username = "lecturer", Password = "lecturer123", Role = "Lecturer" }
            );

            modelBuilder.Entity<Claim>().HasData(
                new Claim
                {
                    ClaimId = 1,
                    LecturerId = 2,
                    Description = "Claim for teaching hours",
                    HoursWorked = 20,
                    HourlyRate = 50,
                    Status = "Pending",
                    UploadedDocumentPath = "/docs/sample.pdf",
                    RejectionReason = "" 
                }
            );
        }
    }
}

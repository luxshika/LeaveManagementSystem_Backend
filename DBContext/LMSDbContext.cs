using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.DBContext
{
    public class LMSDbContext:DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) { }
        public DbSet<Leave> leaves { get; set; } = null!;
        public DbSet<Employee> employees { get; set; } = null!;
        public DbSet<Position> positions { get; set; } = null!;
        public DbSet<Company> companies { get; set; } = null!;
        public DbSet<HolidayType> holidaytypes { get; set; } = null!;
        public DbSet<Holiday> holidays { get; set; }

        public DbSet<LeaveType> leavetypes { get; set; } = null!;

        public DbSet<AllocatedLeave> allocatedLeaves { get; set; } = null!;

        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamMember> TeamMembers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.EmployeeId });

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(tm => tm.TeamId);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Employee)
                .WithMany(e => e.TeamMembers)
                .HasForeignKey(tm => tm.EmployeeId);

          
        }

        public DbSet<Review> reviews { get; set; } = null!;
        public DbSet<AllocatedSetup> AllocatedSetups { get; set; }  = null!;
    }
}

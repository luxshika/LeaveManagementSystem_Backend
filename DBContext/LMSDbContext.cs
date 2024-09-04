using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.DBContext
{
    public class LMSDbContext:DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) { }
        public DbSet<Leave> Leaves { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<HolidayType> Holidaytypes { get; set; } = null!;
        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<LeaveType> Leavetypes { get; set; } = null!;

        public DbSet<AllocatedLeave> AllocatedLeaves { get; set; } = null!;

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

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeNumber)
                .IsUnique();


        }


        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<AllocatedSetup> AllocatedSetups { get; set; }  = null!;

        public DbSet<User> Users { get; set; } = null!;



    }
}

using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Repository;
using LeaveManagementSystem_Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LMSDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<LeaveContext>(opt =>
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddDbContext<PositionContext>(opt =>
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();

builder.Services.AddScoped<IHolidayService,HolidayService>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();

builder.Services.AddScoped<ITeamService,TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IAllocatedLeaveRepository,AllocatedLeaveRepository>();
builder.Services.AddScoped<IAllocatedLeaveService, AllocatedLeaveService>();

builder.Services.AddScoped<IAllocatedSetupRepository, AllocatedSetupRepository>();
builder.Services.AddScoped<IAllocatedSetupService, AllocatedSetupService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

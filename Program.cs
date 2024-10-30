using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Repository;
using LeaveManagementSystem_Backend.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
   .AddJsonOptions(options =>
   {
       options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
   });

builder.Services.AddDbContext<LMSDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repositories and services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();

builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IAllocatedLeaveRepository, AllocatedLeaveRepository>();
builder.Services.AddScoped<IAllocatedLeaveService, AllocatedLeaveService>();

builder.Services.AddScoped<IAllocatedSetupRepository, AllocatedSetupRepository>();
builder.Services.AddScoped<IAllocatedSetupService, AllocatedSetupService>();

builder.Services.AddScoped<IHolidayTypeService, HolidayTypeService>();
builder.Services.AddScoped<IHolidayTypeRepository, HoildayTypeRepository>();

// Configure CORS policy
builder.Services.AddCors(corsoptions =>
{
    corsoptions.AddPolicy("MyPolicy", policyoptions =>
    {
        policyoptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply the CORS policy
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

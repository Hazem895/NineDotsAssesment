using FluentValidation;
using LearnWebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using NineDotsAssesment.Core.ExternalServices;
using NineDotsAssesment.Core.ExternalServices.Interface;
using NineDotsAssesment.Core.Services;
using NineDotsAssesment.Core.Services.Interface;
using NineDotsAssesment.Core.Validation;
using NineDotsAssesment.Domain.Entities;
using NineDotsAssesment.Domain.IRepository;
using NineDotsAssesment.Infrastructure.Sql;
using NineDotsAssesment.Infrastructure.Sql.Repository.DriversRepository;
using NineDotsAssesment.Shared.DTO;
using NineDotsAssesment.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnectionString")));

builder.Services.AddScoped<ICrudCommandsRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IMobileOTPService, MobileOTPService>();
builder.Services.AddScoped<IEmailOTPService, EmailOTPService>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IOTPServices, OTPServices>();

builder.Services.AddScoped<IValidator<CustomerDTO>, CustomerValidator>();
builder.Services.AddScoped<IValidator<ConfirmPINModel>, PINValidator>();
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.Run();

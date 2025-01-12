using FluentValidation;
using FluentValidation.AspNetCore;
using FornecedoresApp.ApplicationServices.Interfaces;
using FornecedoresApp.ApplicationServices.Profiles;
using FornecedoresApp.ApplicationServices.Services;
using FornecedoresApp.ApplicationServices.Validators;
using FornecedoresApp.DomainModels;
using FornecedoresApp.DomainServices.Interfaces;
using FornecedoresApp.DomainServices.Services;
using FornecedoresApp.Infrastructure;
using FornecedoresApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FornecedoresDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FornecedoresDB")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFornecedoresAppService, FornecedoresAppService>();
builder.Services.AddScoped<IFornecedoresService, FornecedoresService>();
builder.Services.AddAutoMapper(typeof(FornecedoresProfile));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<FornecedoresValidator>();

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

using MediatR;
using System.Reflection;
using ISC_Sample.Domain.Repository;
using ISC_Sample.EntityFrameworkCore.ISCDbContextProject;
using ISC_Sample.Handler.JournalHandler;
using ISC_Sample.Repository.JournalRepository;
using ISC_Sample.Repository.OrganizationRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<IscDbContext>();
builder.Services.AddScoped<IJournalRepository, JournalRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddMediatR(typeof(CreateJournalHandler).Assembly);
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
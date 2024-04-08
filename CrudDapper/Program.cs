using FiapSchool.Application.Mappings;
using FiapSchool.Infrastructure.Services;
using FiapSchool.Infrastructure.Services.AlunoService;
using FiapSchool.Infrastructure.Services.AlunoTurmaService;
using FiapSchool.Infrastructure.Services.TurmaService;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IDbConnection>(provider =>
    provider.GetRequiredService<DbConnectionFactory>().CreateConnection());

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

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

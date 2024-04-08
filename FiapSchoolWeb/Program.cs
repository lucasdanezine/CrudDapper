using FiapSchoolWeb.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FiapSchoolWeb.Data;
using Microsoft.AspNetCore.Identity;
using FiapSchool.Infrastructure.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FiapSchoolWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FiapSchoolWebContext") ?? throw new InvalidOperationException("Connection string 'FiapSchoolWebContext' not found.")));

builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IDbConnection>(provider =>
    provider.GetRequiredService<DbConnectionFactory>().CreateConnection());

builder.Services.AddQuickGridEntityFrameworkAdapter();


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

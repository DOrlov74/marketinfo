using Microsoft.EntityFrameworkCore;
using MarketInfo.Data;
using System;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyContext>(opt =>
    opt.UseInMemoryDatabase("CompanyList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
  opt.AddPolicy("CorsPolicy", policy =>
  {
    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
  });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
using var dbContext = scope.ServiceProvider.GetRequiredService<CompanyContext>();
dbContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

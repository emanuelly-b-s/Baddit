using Back.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Back.Repositories.User;

// using Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MainPolicy", cors =>
    {
        cors
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
    });
});

builder.Services.AddScoped<BadditContext>();
builder.Services.AddTransient<IRepository<ImageDatum>, ImageRepository>();
builder.Services.AddTransient<IRepository<UserBaddit>, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();


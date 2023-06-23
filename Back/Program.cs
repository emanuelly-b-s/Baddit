using Back.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Back.Repositories.User;

// using Model;

var builder = WebApplication.CreateBuilder(args);

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

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


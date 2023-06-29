using Back.Model;
using Back.Repositories.ForumRep;
using Back.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SecurityService;
using System.Text;


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

builder.Services.AddTransient<IRepository<ImageDatum>, ImageRepository>();
builder.Services.AddTransient<IUserRepository<UserBaddit>, UserRepository>();
builder.Services.AddTransient<IForumRepository<Forum>, ForumRepository>();
builder.Services.AddTransient<ISecurityServiceJwt, SecurityServiceJwt>();
builder.Services.AddScoped<BadditContext>();

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


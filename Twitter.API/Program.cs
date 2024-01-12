using Microsoft.EntityFrameworkCore;
using Twitter.DAL.Contexts;
using Twitter.Business;
using Microsoft.AspNetCore.Identity;
using Twitter.Core.Entities;
using Twitter.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Twitter.Core.Enums;
using Twitter.Business.Exceptions.AppUser;
using Twitter.API.Helpers;

var builder = WebApplication.CreateBuilder(args);
var jwt = builder.Configuration.GetSection("Jwt").Get<Jwt>();
builder.Services.AddControllers();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(pol =>
    {
        pol.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<TwitterContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
builder.Services.AddUserIdentity();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddBusinessLayer();
builder.Services.AddAuth(jwt);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSeedData();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    }); ;
}

app.UseHttpsRedirection();
app.UseCors();
app.UseCustomExceptionHandler();
//app.Use(async (context, n) =>
//{
//    var a = context.Connection.RemoteIpAddress;
//    await Console.Out.WriteLineAsync("HEEEEEEEEEEEEEEEEREEEEEEEEEEEEEEEEEE");
//    await Console.Out.WriteLineAsync(a.ToString());
//    await n();
//});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CarListApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(o => {
                o.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            var conn = new SqliteConnection($"Data Source=C:\\carlistdb\\carlist.db");
            builder.Services.AddDbContext<CarListDbContext>(o => o.UseSqlite(conn));

            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarListDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.MapGet("/cars", async (CarListDbContext db) => await db.Cars.ToListAsync());

            app.MapGet("/cars/{id}", async (int id, CarListDbContext db) =>
                await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound()
            );

            app.MapPut("/cars/{id}", async (int id, Car car, CarListDbContext db) => {
                var record = await db.Cars.FindAsync(id);
                if (record is null) return Results.NotFound();

                record.Make = car.Make;
                record.Model = car.Model;
                record.Vin = car.Vin;

                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapDelete("/cars/{id}", async (int id, CarListDbContext db) => {
                var record = await db.Cars.FindAsync(id);
                if (record is null) return Results.NotFound();
                db.Remove(record);
                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapPost("/cars", async (Car car, CarListDbContext db) => {
                await db.AddAsync(car);
                await db.SaveChangesAsync();

                return Results.Created($"/cars/{car.Id}", car);

            });

            app.MapPost("/login", async (LoginDto loginDto, UserManager<IdentityUser> _userManager) => {
                var user = await _userManager.FindByNameAsync(loginDto.Username);

                if (user is null)
                {
                    return Results.Unauthorized();
                }

                var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (!isValidPassword)
                {
                    return  Results.Unauthorized();
                }

                // Generate an access token
               /* var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var roles = await _userManager.GetRolesAsync(user);
                var claims = await _userManager.GetClaimsAsync(user);
                var tokenClaims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("email_confirmed", user.EmailConfirmed.ToString())
    }.Union(claims)
                .Union(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var securityToken = new JwtSecurityToken(
                    issuer: builder.Configuration["JwtSettings:Issuer"],
                    audience: builder.Configuration["JwtSettings:Audience"],
                    claims: tokenClaims,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(builder.Configuration["JwtSettings:DurationInMintues"])),
                    signingCredentials: credentials
                );

                var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);*/


                var response = new AuthResponseDto
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Token = "AccessTokenHere"
                };

                return Results.Ok(response);
            }).AllowAnonymous();


            app.Run();


        }
    }

  
    internal class LoginDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    internal class AuthResponseDto
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public object Token { get; set; }
    }

}
using Microsoft.EntityFrameworkCore;
using SpotifyLite.Application.Profile;
using SpotifyLite.Application.Service;
using SpotifyLite.Domain.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Repository;

namespace SpotifyLite.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            //builder.Services
            //       .RegisterApplication()
            //       .RegisterRepository(builder.Configuration.GetConnectionString("SpotifyLite"));
            builder.Services.AddDbContext<SpotifyLiteContext>(c =>
            {
                c.UseLazyLoadingProxies()
                 .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
            });

            builder.Services.AddAutoMapper(typeof(Profile).Assembly);

            //Repositories
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();

            //Services
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IPlaylistService, PlaylistService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpotifyLite v1"));
            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
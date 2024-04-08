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
            builder.Services.AddAutoMapper(typeof(Profile).Assembly);
            builder.Services.AddDbContext<SpotifyLiteContext>(c =>
            {
                c.UseLazyLoadingProxies()
                 .UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
            });

            // Services
            builder.Services.AddScoped<IBandaService, BandaService>();
            builder.Services.AddScoped<IPlanoService, PlanoService>();
            builder.Services.AddScoped<IPlaylistService, PlaylistService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            // Repositories
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IBandaRepository, BandaRepository>();
            builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpotifyLite v1"));
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SpotifyLite.Application.Service;
using System.Reflection;

namespace SpotifyLite.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);
            services.AddMediatR(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IBandaService, BandaService>();
            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}

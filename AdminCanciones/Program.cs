using AdminCanciones.Components;
using AdminCanciones.Components.Data;
using AdminCanciones.Repositorio;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddDbContext<BasedeDatosDbContext>(
    options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString(
                        "DefaultConnection")));

        builder.Services.AddScoped<IRepositorioCanciones, RepositorioCancion>();
        builder.Services.AddScoped<IRepositorioArtistas, RepositorioArtista>();
        builder.Services.AddScoped<IRepositorioAlbums, RepositorioAlbum>();
        builder.Services.AddScoped<IRepositorioPlaylists, RepositorioPlaylist>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}

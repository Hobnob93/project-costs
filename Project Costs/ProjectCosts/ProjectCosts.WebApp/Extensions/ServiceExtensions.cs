using Fluxor;
using MudBlazor;
using MudBlazor.Services;
using ProjectCosts.Web.State.Assembly;

namespace ProjectCosts.Web.Extensions;

public static class ServiceExtensions
{
    public static void SetupMudBlazor(this IServiceCollection services)
    {
        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
        });
    }

    public static void SetupFluxor(this IServiceCollection services)
    {
        services.AddFluxor(config =>
        {
            config.ScanAssemblies(WebStateAssembly.Value);
            config.UseReduxDevTools();
        });
    }
}

using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using ProjectCosts.Core.Constants;
using ProjectCosts.Core.Options;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectCosts.Web;
using ProjectCosts.Web.Extensions;
using ProjectCosts.Core.Interfaces;
using ProjectCosts.Core.Clients;
using DevTrends.ConfigurationExtensions;
using ProjectCosts.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.SetupMudBlazor();
builder.Services.SetupFluxor();
builder.Services.AddSingleton<Navigation>();

builder.Services.AddTransient<ISimpleThingClient, SimpleThingClient>();

var configuration = builder.Configuration;
builder.Services.AddSingleton(configuration.Bind<ProjectCostsApiOptions>(ProjectCostsApiOptions.ConfigSection));

builder.Services.AddHttpClient(ApiClientNames.ProjectCostsApiClientName,
    (sp, client) =>
    {
        var options = sp.GetRequiredService<ProjectCostsApiOptions>();
        client.BaseAddress = new Uri(options.BaseUrl);
    })
    .AddTransientHttpErrorPolicy(pb => pb.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)));

await builder.Build().RunAsync();

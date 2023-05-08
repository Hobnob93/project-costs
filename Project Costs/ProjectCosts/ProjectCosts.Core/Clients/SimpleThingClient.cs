using OneOf;
using OneOf.Types;
using ProjectCosts.Core.Constants;
using ProjectCosts.Core.Interfaces;
using ProjectCosts.Core.Models;
using ProjectCosts.Core.Options;
using System.Net.Http.Json;

namespace ProjectCosts.Core.Clients;

public class SimpleThingClient : ISimpleThingClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ProjectCostsApiOptions _options;

    public SimpleThingClient(IHttpClientFactory httpClientFactory, ProjectCostsApiOptions options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
    }

    public async Task<OneOf<List<ThingOverview>, Error<string>>> GetSimpleThingsAsync()
    {
        try
        {
            return await CreateClient().GetFromJsonAsync<List<ThingOverview>>(_options.GetSimpleThings)
                ?? new List<ThingOverview>();
        }
        catch (Exception ex)
        {
            return new Error<string>(ex.Message);
        }
    }

    public async Task<OneOf<ThingOverview, NotFound, Error<string>>> GetSimpleThingAsync(string id)
    {
        try
        {
            var uri = string.Format(_options.GetSimpleThing, id);
            var result = await CreateClient().GetFromJsonAsync<ThingOverview>(uri);

            if (result is not null)
                return result;

            return new NotFound();
        }
        catch (Exception ex)
        {
            return new Error<string>(ex.Message);
        }
    }

    public async Task<OneOf<ThingOverview, Error<string>>> CreateSimpleThingAsync(ThingOverview thing)
    {
        try
        {
            var result = await CreateClient().PostAsJsonAsync(_options.CreateSimpleThing, thing);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<ThingOverview>()
                ?? throw new InvalidOperationException("Create action succeeded, but nothing was returned!");
        }
        catch (Exception ex)
        {
            return new Error<string>(ex.Message);
        }
    }

    public async Task<OneOf<ThingOverview, Error<string>>> UpdateSimpleThingAsync(ThingOverview thing)
    {
        try
        {
            var result = await CreateClient().PutAsJsonAsync(_options.UpdateSimpleThing, thing);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<ThingOverview>()
                ?? throw new InvalidOperationException("Update action succeeded but nothing was returned!");
        }
        catch (Exception ex)
        {
            return new Error<string>(ex.Message);
        }
    }

    public async Task<OneOf<Success, Error<string>>> DeleteSimpleThingAsync(string id)
    {
        try
        {
            var uri = string.Format(_options.DeleteSimpleThing, id);
            var result = await CreateClient().DeleteAsync(uri);
            result.EnsureSuccessStatusCode();
            return new Success();
        }
        catch (Exception ex)
        {
            return new Error<string>(ex.Message);
        }
    }

    private HttpClient CreateClient() =>
        _httpClientFactory.CreateClient(ApiClientNames.ProjectCostsApiClientName);
}

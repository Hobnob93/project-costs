using Microsoft.Extensions.Options;
using Polly;
using Polly.Contrib.WaitAndRetry;
using ProjectCosts.Core.Constants;
using ProjectCosts.Core.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.Configure<ProjectCostsApiOptions>(configuration.GetSection(ProjectCostsApiOptions.ConfigSection));

builder.Services.AddHttpClient(ApiClientNames.ProjectCostsApiClientName,
    (sp, client) =>
    {
        var options = sp.GetRequiredService<IOptions<ProjectCostsApiOptions>>().Value;
        client.BaseAddress = new Uri(options.BaseUrl);
    })
    .AddTransientHttpErrorPolicy(pb => pb.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();

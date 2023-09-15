

using Microsoft.Extensions.Options;
using OptionExample;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<ApplicationOptions>(
//    builder.Configuration.GetSection(nameof(ApplicationOptions)));

builder.Services.ConfigureOptions<ApplicationOptionSetup>(); 

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("options", (IOptions<ApplicationOptions> options,
    IOptionsSnapshot<ApplicationOptions> optionsSnapshot,
    IOptionsMonitor<ApplicationOptions> optionsMonitor) => {
        var response = new
        {
            OptionValue = options.Value.ExampleValue,
            SnapshotValue = optionsSnapshot.Value.ExampleValue,
            MonitorValue = optionsMonitor.CurrentValue.ExampleValue
    };
    return Results.Ok(response); 
});

app.Run();

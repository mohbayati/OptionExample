

using Microsoft.Extensions.Options;
using OptionExample;

var builder = WebApplication.CreateBuilder(args);


//this one can use without ApplicationOptionSetup
//builder.Services.Configure<ApplicationOptions>(
//    builder.Configuration.GetSection(nameof(ApplicationOptions)));

//builder.Services.ConfigureOptions<ApplicationOptionSetup>();

builder.Services.AddOptions<ApplicationOptions>()
            .BindConfiguration(nameof(ApplicationOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

builder.Services.AddScoped(sp => sp.GetRequiredService<IOptionsSnapshot<ApplicationOptions>>().Value);

var app = builder.Build();

app.UseHttpsRedirection();

//app.MapGet("options", (IOptions<ApplicationOptions> options,
//    IOptionsSnapshot<ApplicationOptions> optionsSnapshot,
//    IOptionsMonitor<ApplicationOptions> optionsMonitor) => {
//        var response = new
//        {
//            OptionValue = options.Value.ExampleValue,
//            SnapshotValue = optionsSnapshot.Value.ExampleValue,
//            MonitorValue = optionsMonitor.CurrentValue.ExampleValue
//    };
//    return Results.Ok(response); 
//});

app.MapGet("/", (ApplicationOptions options) =>
{
    return Results.Ok(options);
});

app.Run();

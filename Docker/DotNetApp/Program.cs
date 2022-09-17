
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


if (builder.Configuration.GetValue<bool>("Redis:Enabled"))
{

    builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    {
        return ConnectionMultiplexer.Connect(builder.Configuration.GetValue<string>("Redis:Connection"));
    });
}

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();

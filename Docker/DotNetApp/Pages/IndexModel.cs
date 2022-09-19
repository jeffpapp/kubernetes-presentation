using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackExchange.Redis;

namespace DotNetApp.Pages;

[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    private readonly IConfiguration configuration;
    private readonly IConnectionMultiplexer? connectionMultiplexer;

    public IndexModel(IServiceProvider serviceProvider)
    {
        configuration = serviceProvider.GetRequiredService<IConfiguration>();
        connectionMultiplexer = serviceProvider.GetService<IConnectionMultiplexer>();
    }


    public string LastClickedTime { get; set; } = "Never";

    public bool RedisEnabled { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var redisEnabled = configuration.GetValue<bool>("Redis:Enabled");

        if (redisEnabled)
        {
            var database = connectionMultiplexer!.GetDatabase();

            var lastClickedTime = await database.StringGetAsync("LastClickedTime");

            if (lastClickedTime != RedisValue.Null)
            {
                LastClickedTime = lastClickedTime!;
            }
        }


        RedisEnabled = redisEnabled;


        return Page();

    }


    public async Task<IActionResult> OnPostAsync()
    {
        var redisEnabled = configuration.GetValue<bool>("Redis:Enabled");

        if (redisEnabled)
        {
            var database = connectionMultiplexer!.GetDatabase();

            await database.StringSetAsync("LastClickedTime", DateTimeOffset.Now.ToString("hh:mm:ss tt MM/dd/yyyy"));
        }

        return RedirectToPage();

    }

}

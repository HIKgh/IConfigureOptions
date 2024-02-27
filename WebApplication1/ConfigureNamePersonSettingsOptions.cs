using Microsoft.Extensions.Options;

namespace WebApplication1;

public class ConfigureNameSlackApiSettingsOptions : IConfigureNamedOptions<SlackApiSettings>
{
    public void Configure(string name, SlackApiSettings options)
    {
        if (name == "Dev")
        {
            options.DisplayName = "DEV DisplayName";
        }
    }

    public void Configure(SlackApiSettings options)
        => Configure(Options.DefaultName, options);
}
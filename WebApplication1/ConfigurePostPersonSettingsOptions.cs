using Microsoft.Extensions.Options;

namespace WebApplication1;

public class ConfigurePostPersonSettingsOptions : IPostConfigureOptions<PersonSettings>
{
    private readonly Provider _provider;

    public ConfigurePostPersonSettingsOptions()
        => _provider = new Provider("MyProvider");

    public void PostConfigure(string? name, PersonSettings options)
    {
        options.Provider = _provider;
        options.NameSettings.LastName = "Smith";
    }
}
using Microsoft.Extensions.Options;

namespace WebApplication1;

public class ConfigurePersonSettingsOptions : IConfigureOptions<PersonSettings>
{
    private readonly IRandomService _service;
    public ConfigurePersonSettingsOptions(IRandomService service)
    {
        _service = service;
    }

    public void Configure(PersonSettings options)
    {
        options.Age = _service.Get();
    }
}
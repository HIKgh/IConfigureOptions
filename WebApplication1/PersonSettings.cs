namespace WebApplication1;

public class PersonSettings
{
    public NameSettings NameSettings { get; set; }
    public WorkSettings WorkSettings { get; set; }
    public int Age { get; set; }
    public string Nick { get; set; }
    public Provider Provider { get; set; }
}

public class NameSettings
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SurName { get; set; }
}

public class WorkSettings
{
    public string Job { get; set; }
    public string Team { get; set; }
}

public class Provider
{
    private string _name;

    public Provider(string name) => _name = name;
}

public class SlackApiSettings
{
    public string WebhookUrl { get; set; }
    public string DisplayName { get; set; }
}
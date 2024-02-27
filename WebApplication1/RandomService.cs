namespace WebApplication1;

public interface IRandomService
{
    int Get();
}

public class RandomService : IRandomService
{
    private const int MaxInt = 10;

    private readonly Random _random = new();

    public int Get() => _random.Next(MaxInt);
}
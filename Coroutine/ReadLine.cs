namespace Coroutine;

public record ReadLine() : IEffect<string?>
{
    public IEnumerable<string?> Result { get; set; } = Enumerable.Empty<string?>();

    public async Task ExecuteAsync()
    {
        Result = new List<string?>
        {
            await Task.FromResult(Console.ReadLine())
        };
    }
}

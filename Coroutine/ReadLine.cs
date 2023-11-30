namespace Coroutine;

public record ReadLine() : IEffect<string?>
{
    public string? Result { get; set; }

    public async Task ExecuteAsync()
    {
        Result = await Task.FromResult(Console.ReadLine());
    }
}

namespace Coroutine;

public record WriteLine(string Text) : IEffect
{
    public async Task ExecuteAsync()
    {
        Console.WriteLine(Text);
        await Task.CompletedTask;
    }
}

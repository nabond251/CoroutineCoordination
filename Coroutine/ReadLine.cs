namespace Coroutine;

public record ReadLine() : IEffect<string>
{
    public string? Result { get; set; }

    public void Execute()
    {
        Result = Console.ReadLine();
    }
}

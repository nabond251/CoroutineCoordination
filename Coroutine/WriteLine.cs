namespace Coroutine;

public record WriteLine(string Text) : IEffect
{
    public void Execute()
    {
        Console.WriteLine(Text);
    }
}

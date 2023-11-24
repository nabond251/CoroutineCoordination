namespace Coroutine;

public record ReadLine() : IEffect<string>
{
    public string? Result { get; set; }

    public void Execute()
    {
        Result = Console.ReadLine();
    }
}

public record WriteLine(string Text) : IEffect
{
    public void Execute()
    {
        Console.WriteLine(Text);
    }
}

public record Call<T>(BaseCoroutine<T> Program) : IEffect<T>
{
    public T? Result { get; set; }

    public void Execute()
    {
        foreach (var i in Program)
        {
            i.Execute();
        }

        Result = Program.Result;
    }
}

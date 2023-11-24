namespace Coroutine;

public record Call<T>(Coroutine<T> Program) : IEffect<T>
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

namespace Coroutine;

public record Call<T>(Coroutine<T> Program) : IEffect<T>
{
    public T? Result { get; set; }

    public async Task ExecuteAsync()
    {
        foreach (var i in Program)
        {
            await i.ExecuteAsync();
        }

        Result = Program.Result;
    }
}

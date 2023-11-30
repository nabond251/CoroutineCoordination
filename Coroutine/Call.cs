namespace Coroutine;

public record Call<T>(Coroutine<T> Program) : IEffect<T>
{
    public T? Result { get; set; }

    public async Task ExecuteAsync()
    {
        this.Result = await Interpreter.InterpretAsync(this.Program);
    }
}

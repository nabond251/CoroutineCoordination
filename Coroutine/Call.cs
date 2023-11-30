namespace Coroutine;

public record Call<T>(Coroutine<T> Program) : IEffect<T>
{
    public IEnumerable<T> Result { get; set; } = Enumerable.Empty<T>();

    public async Task ExecuteAsync()
    {
        this.Result = await Interpreter.InterpretAsync(this.Program);
    }
}

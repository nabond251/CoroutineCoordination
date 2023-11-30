namespace Coroutine;

public record Call<T>(Coroutine<T> Program) : IEffect<IEnumerable<T?>>
{
    public IEnumerable<T?>? Result { get; set; }

    public async Task ExecuteAsync()
    {
        this.Result = await Interpreter.InterpretAsync(this.Program);
    }
}

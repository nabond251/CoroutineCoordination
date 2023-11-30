namespace Coroutine;

public static class Interpreter
{
    public static async Task<T?> InterpretAsync<T>(Coroutine<T> program)
    {
        foreach (var i in program)
        {
            await i.ExecuteAsync();
            if (i is Coroutine<T>.Return r)
            {
                return r.Result;
            }
        }

        throw new InvalidOperationException();
    }
}

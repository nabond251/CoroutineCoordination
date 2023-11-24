namespace Coroutine;

public static class Interpreter
{
    public static async Task<T?> InterpretAsync<T>(Coroutine<T> program)
    {
        foreach (var i in program)
        {
            await i.ExecuteAsync();
        }

        return program.Result;
    }
}

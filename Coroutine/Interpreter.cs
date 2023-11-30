namespace Coroutine;

public static class Interpreter
{
    public static async Task<IEnumerable<T?>> InterpretAsync<T>(Coroutine<T> program)
    {
        var retVal = new List<T?>();
        foreach (var i in program)
        {
            await i.ExecuteAsync();
            if (i is Coroutine<T>.Result r)
            {
                retVal.Add(r.Value);
            }
        }

        return retVal;
    }
}

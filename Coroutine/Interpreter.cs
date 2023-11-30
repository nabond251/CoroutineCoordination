namespace Coroutine;

public static class Interpreter
{
    public static async Task<IEnumerable<T>> InterpretAsync<T>(Coroutine<T> program)
    {
        async IAsyncEnumerable<T> GetEnumerableAsync()
        {
            foreach (var i in program)
            {
                await i.ExecuteAsync();
                if (i is Coroutine<T>.Result r)
                {
                    yield return r.Value;
                }
            }
        }

        return await GetEnumerableAsync().ToListAsync();
    }
}

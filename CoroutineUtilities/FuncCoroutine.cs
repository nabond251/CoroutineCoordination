namespace CoroutineUtilities;

using System.Collections;

public class FuncCoroutine<T> : IFuncCoroutine<T>
{
    public FuncCoroutine(Func<T> func)
    {
        this.Func = func;
    }

    public Func<T> Func { get; }

    public T? NextValue { get; set; }

    public IEnumerator<Unit> GetEnumerator()
    {
        yield return new Unit();
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

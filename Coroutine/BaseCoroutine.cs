namespace Coroutine;

using System.Collections;
using System.Threading.Channels;

public abstract class BaseCoroutine<T, TReturn> : IEnumerable<T>
{
    public TReturn? Result { get; protected set; }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

namespace Coroutine;

using System.Collections;

public abstract class BaseCoroutine<T> : IEnumerable<IEffect>
{
    public T? Result { get; protected set; }

    public abstract IEnumerator<IEffect> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

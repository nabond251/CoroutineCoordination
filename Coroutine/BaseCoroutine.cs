namespace Coroutine;

using System.Collections;
using System.Threading.Channels;

public abstract class BaseCoroutine<T, TReturn, TNext> : IEnumerable<T>
{
    protected BaseCoroutine(ChannelReader<TNext> next)
    {
        this.Next = next;
    }

    public ChannelReader<TNext> Next { get; }

    public TReturn? Return { get; protected set; }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

namespace Coroutine;

using System.Collections;
using System.Threading.Channels;

public abstract class BaseCoroutine<T, TReturn, TNext> : IEnumerable<T>
{
    protected BaseCoroutine(ChannelReader<TNext> nextReader)
    {
        this.NextReader = nextReader;
    }

    public ChannelReader<TNext> NextReader { get; }

    public TReturn? Return { get; protected set; }

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

namespace Coroutine;

using System.Collections;
using System.Threading.Tasks;

public abstract class Coroutine<T> : IEnumerable<IEffect>
{
    public abstract IEnumerator<IEffect> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();

    public record Result(T? Value) : IEffect
    {
        public Task ExecuteAsync() =>
            Task.CompletedTask;
    }
}

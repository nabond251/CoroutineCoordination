namespace Coroutine;

using System.Collections;
using System.Threading.Tasks;

public abstract class Coroutine<T> : IEnumerable<IEffect>
{
    public abstract IEnumerator<IEffect> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();

    public record Result : IEffect
    {
        private readonly T? value;

        public Result(T? value)
        {
            this.value = value;
        }

        public T? Value { get; private set; }

        public Task ExecuteAsync()
        {
            this.Value = this.value;
            return Task.CompletedTask;
        }
    }
}

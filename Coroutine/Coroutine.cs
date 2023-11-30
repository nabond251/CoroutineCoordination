namespace Coroutine;

using System.Collections;
using System.Threading.Tasks;

public abstract class Coroutine<T> : IEnumerable<IEffect>
{
    public abstract IEnumerator<IEffect> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();

    public record Return : IEffect<T>
    {
        private readonly T? result;

        public Return(T? result)
        {
            this.result = result;
        }

        public T? Result { get; private set; }

        public Task ExecuteAsync()
        {
            this.Result = this.result;
            return Task.CompletedTask;
        }
    }
}

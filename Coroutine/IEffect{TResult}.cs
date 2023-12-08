namespace Coroutine;

public interface IEffect<out TResult> : IEffect
{
    IEnumerable<TResult> Result { get; }
}

namespace Coroutine;

public interface IEffect<out TResult> : IEffect
{
    TResult? Result { get; }
}

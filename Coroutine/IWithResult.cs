namespace Coroutine;

public interface IWithResult<T>
{
    T? Result { get; set; }
}

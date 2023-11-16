namespace CoroutineUtilities;

public interface IFuncCoroutine<T> : IEnumerable<Unit>
{
    T? NextValue { get; set; }
}

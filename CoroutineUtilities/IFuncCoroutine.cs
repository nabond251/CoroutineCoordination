namespace CoroutineUtilities;

public interface IFuncCoroutine<T>
{
    T? NextValue { get; set; }
}

namespace CoroutineUtilities;

using System.Collections;

public class FuncCoroutine<T> : IFuncCoroutine<T>
{
    public T? NextValue { get; set; }
}

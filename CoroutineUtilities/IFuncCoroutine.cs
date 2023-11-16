namespace CoroutineCommandLine
{
    public interface IFuncCoroutine<T> : IEnumerable<Unit>
    {
        Func<T> Func { get; }

        T? NextValue { get; set; }
    }
}
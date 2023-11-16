namespace CoroutineCoordinationTests
{
    using System.Collections;
    using CoroutineCommandLine;
    using CoroutineUtilities;

    internal class MockReadLineCoroutine : IFuncCoroutine<string?>
    {
        public Func<string?> Func { get; } = () => null;

        public string? NextValue { get; set; }

        public IEnumerator<Unit> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
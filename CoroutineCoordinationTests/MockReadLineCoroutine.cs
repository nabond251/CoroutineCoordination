namespace CoroutineCoordinationTests
{
    using System.Collections;
    using CoroutineCommandLine;
    using CoroutineUtilities;

    internal class MockReadLineCoroutine : IFuncCoroutine<string?>
    {
        public string? NextValue { get; set; }
    }
}
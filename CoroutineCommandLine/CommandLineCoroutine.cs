namespace CoroutineCommandLine;

using System.Collections;

public abstract class CommandLineCoroutine : IEnumerable<CommandLineSink>
{
    public CommandLineSource? NextValue { protected get; set; }

    public abstract IEnumerator<CommandLineSink> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

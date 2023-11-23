namespace CoroutineCoordination;

using CoroutineCommandLine;

public class CommandLineWizard : CommandLineCoroutine
{
    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield break;
    }
}

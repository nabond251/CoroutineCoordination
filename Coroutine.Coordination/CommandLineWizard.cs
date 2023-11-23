namespace Coroutine.Coordination;

public class CommandLineWizard : CommandLineCoroutine<Unit>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        yield break;
    }
}

namespace Coroutine.Coordination;

public class HelloCommandLine : CommandLineCoroutine<Unit>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        yield return new CommandLineEffect.WriteLine("Please enter your name.");

        var nameEffect = new CommandLineEffect.ReadLine();
        yield return nameEffect;

        yield return new CommandLineEffect.WriteLine($"Hello, {nameEffect.Result}!");
    }
}

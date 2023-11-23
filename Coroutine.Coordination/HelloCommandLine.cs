using System.Threading.Channels;

namespace Coroutine.Coordination;

public class HelloCommandLine : CommandLineCoroutine<Unit>
{
    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");

        var nameEffect = new CommandLineSink.ReadLine();
        yield return nameEffect;

        yield return new CommandLineSink.WriteLine($"Hello, {nameEffect.Result}!");
    }
}

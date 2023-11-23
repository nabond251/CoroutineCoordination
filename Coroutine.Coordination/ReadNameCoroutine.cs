namespace Coroutine.Coordination;

public class ReadNameCoroutine : CommandLineCoroutine<string>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        yield return new CommandLineEffect.WriteLine(
            "Please enter your name:");

        var name = new CommandLineEffect.ReadLine();
        yield return name;
        Result = name.Result;
    }
}

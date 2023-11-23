namespace Coroutine.Coordination;

public class ReadEmailCoroutine : CommandLineCoroutine<string>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        yield return new CommandLineEffect.WriteLine(
            "Please enter your email address:");

        var email = new CommandLineEffect.ReadLine();
        yield return email;
        Result = email.Result;
    }
}

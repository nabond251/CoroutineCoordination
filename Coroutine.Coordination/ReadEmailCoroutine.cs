namespace Coroutine.Coordination;

public class ReadEmailCoroutine : CommandLineCoroutine<string>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter your email address:");

        var email = new ReadLine();
        yield return email;
        Result = email.Result;
    }
}

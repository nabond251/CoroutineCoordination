namespace Coroutine.Coordination;

public class ReadEmailCoroutine : Coroutine<string?>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter your email address:");

        var email = new ReadLine();
        yield return email;

        yield return new Result(email.Result.Single());
    }
}

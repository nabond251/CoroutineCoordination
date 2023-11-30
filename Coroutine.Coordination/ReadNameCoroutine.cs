namespace Coroutine.Coordination;

public class ReadNameCoroutine : Coroutine<string?>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter your name:");

        var name = new ReadLine();
        yield return name;

        yield return new Result(name.Result);
    }
}

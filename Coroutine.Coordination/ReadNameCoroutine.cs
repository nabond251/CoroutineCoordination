namespace Coroutine.Coordination;

public class ReadNameCoroutine : BaseCoroutine<string>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter your name:");

        var name = new ReadLine();
        yield return name;
        Result = name.Result;
    }
}

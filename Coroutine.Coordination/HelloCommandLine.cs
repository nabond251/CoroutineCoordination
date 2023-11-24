namespace Coroutine.Coordination;

public class HelloCommandLine : Coroutine<Unit>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine("Please enter your name.");

        var nameEffect = new ReadLine();
        yield return nameEffect;

        yield return new WriteLine($"Hello, {nameEffect.Result}!");
    }
}

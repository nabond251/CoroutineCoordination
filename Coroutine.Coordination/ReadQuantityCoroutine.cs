namespace Coroutine.Coordination;

using System.Collections;

public class ReadQuantityCoroutine : IEnumerable<ReadQuantitySink>
{
    public IEnumerator<ReadQuantitySink> GetEnumerator()
    {
        yield return new ReadQuantitySink.CommandLine(
            new CommandLineEffect.WriteLine("Please enter number of diners:"));

        var quantity = new CommandLineEffect.ReadLine();
        yield return new ReadQuantitySink.CommandLine(quantity);
        var l = quantity.Result;

        if (int.TryParse(l, out var dinerCount))
        {
            yield return new ReadQuantitySink.Response(dinerCount);
        }
        else
        {
            yield return new ReadQuantitySink.CommandLine(
                new CommandLineEffect.WriteLine("Not an integer."));

            yield return new ReadQuantitySink.Call(
                new ReadQuantityCoroutine());
        }
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

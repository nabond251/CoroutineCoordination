namespace CoroutineCoordination;

using System.Collections;
using CoroutineCommandLine;

public class ReadQuantityCoroutine : IEnumerable<ReadQuantitySink>
{
    public CommandLineSource? NextValue { protected get; set; }

    public IEnumerator<ReadQuantitySink> GetEnumerator()
    {
        yield return new ReadQuantitySink.CommandLine(
            new CommandLineSink.WriteLine("Please enter number of diners:"));

        yield return new ReadQuantitySink.CommandLine(
            new CommandLineSink.ReadLine());
        var l = this.NextValue as CommandLineSource.ReadLine ??
            throw new InvalidOperationException();

        if (int.TryParse(l.Text, out var dinerCount))
        {
            yield return new ReadQuantitySink.Response(dinerCount);
        }
        else
        {
            yield return new ReadQuantitySink.CommandLine(
                new CommandLineSink.WriteLine("Not an integer."));

            yield return new ReadQuantitySink.Call(
                new ReadQuantityCoroutine());
        }
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}

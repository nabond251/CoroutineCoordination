namespace Coroutine.Coordination;

public class ReadQuantityCoroutine : CommandLineCoroutine<int>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        yield return new CommandLineEffect.WriteLine(
            "Please enter number of diners:");

        var quantity = new CommandLineEffect.ReadLine();
        yield return quantity;
        var l = quantity.Result;

        if (int.TryParse(l, out var dinerCount))
        {
            Result = dinerCount;
        }
        else
        {
            yield return new CommandLineEffect.WriteLine(
                "Not an integer.");

            var readQuantity = new CommandLineEffect.Call<int>(
                new ReadQuantityCoroutine());
            yield return readQuantity;
            Result = readQuantity.Result;
        }
    }
}

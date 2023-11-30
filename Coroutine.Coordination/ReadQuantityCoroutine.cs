namespace Coroutine.Coordination;

public class ReadQuantityCoroutine : Coroutine<int>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter number of diners:");

        var quantity = new ReadLine();
        yield return quantity;
        var l = quantity.Result;

        if (int.TryParse(l, out var dinerCount))
        {
            yield return new Return(dinerCount);
        }
        else
        {
            yield return new WriteLine(
                "Not an integer.");

            var readQuantity = new Call<int>(
                new ReadQuantityCoroutine());
            yield return readQuantity;

            yield return new Return(readQuantity.Result);
        }
    }
}

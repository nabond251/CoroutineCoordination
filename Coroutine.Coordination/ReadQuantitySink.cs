namespace Coroutine.Coordination;

public record ReadQuantitySink
{
    public record CommandLine(CommandLineEffect Effect) : ReadQuantitySink();

    public record Call(ReadQuantityCoroutine ReadQuantity) : ReadQuantitySink();

    public record Response(int Quantity) : ReadQuantitySink();

    private ReadQuantitySink() { }
}

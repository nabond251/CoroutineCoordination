using CoroutineCommandLine;

namespace CoroutineCoordination;

public record ReadQuantitySink
{
    public record CommandLine(CommandLineSink Sink) : ReadQuantitySink();

    public record Call(ReadQuantityCoroutine ReadQuantity) : ReadQuantitySink();

    public record Response(int Quantity) : ReadQuantitySink();

    private ReadQuantitySink() { }
}

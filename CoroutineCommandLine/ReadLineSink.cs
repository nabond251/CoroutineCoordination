namespace CoroutineCommandLine;

public record ReadLineSink
{
    public record ReadLine() : ReadLineSink();

    private ReadLineSink() { }
}

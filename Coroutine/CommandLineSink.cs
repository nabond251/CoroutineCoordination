namespace CoroutineCommandLine;

public record CommandLineSink
{
    public record ReadLine() : CommandLineSink();

    public record WriteLine(string Text) : CommandLineSink();

    private CommandLineSink() { }
}

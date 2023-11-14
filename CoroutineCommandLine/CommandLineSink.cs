namespace CoroutineCommandLine;

public record CommandLineSink
{
    public record ReadLine(ReadLineCoroutine Program) : CommandLineSink();

    public record WriteLine(string Text) : CommandLineSink();

    private CommandLineSink() { }
}

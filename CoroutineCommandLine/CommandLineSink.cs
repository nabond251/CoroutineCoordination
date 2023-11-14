namespace CoroutineCommandLine;

public record CommandLineSink
{
    public record ReadLine(FuncCoroutine<string?> Program) : CommandLineSink();

    public record WriteLine(string Text) : CommandLineSink();

    private CommandLineSink() { }
}

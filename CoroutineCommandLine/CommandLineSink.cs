namespace CoroutineCommandLine;

public record CommandLineSink
{
    public record ReadLine(IFuncCoroutine<string?> Program) : CommandLineSink();

    public record WriteLine(string Text) : CommandLineSink();

    private CommandLineSink() { }
}

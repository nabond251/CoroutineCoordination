namespace CoroutineCommandLine;

public record CommandLineSource
{
    public record ReadLine(string? Text) : CommandLineSource();

    public record WriteLine() : CommandLineSource();

    private CommandLineSource() { }
}

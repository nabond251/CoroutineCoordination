namespace CoroutineCommandLine;

public record ReadLineSource
{
    public record ReadLine(string? Text) : ReadLineSource();

    private ReadLineSource() { }
}

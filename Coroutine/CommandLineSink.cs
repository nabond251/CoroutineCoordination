namespace Coroutine;

public record CommandLineSink
{
    public record ReadLine() : CommandLineSink(), IWithResult<string>
    {
        public string? Result { get; set; }
    }

    public record WriteLine(string Text) : CommandLineSink();

    private CommandLineSink() { }
}

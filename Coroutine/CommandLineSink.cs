namespace Coroutine;

public abstract record CommandLineSink : IEffect
{
    public record ReadLine() : CommandLineSink(), IEffect<string>
    {
        public string? Result { get; set; }

        public override void Execute()
        {
            Result = Console.ReadLine();
        }
    }

    public record WriteLine(string Text) : CommandLineSink()
    {
        public override void Execute()
        {
            Console.WriteLine(Text);
        }
    }

    private CommandLineSink() { }

    public abstract void Execute();
}

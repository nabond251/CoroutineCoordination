namespace Coroutine;

public abstract record CommandLineEffect : IEffect
{
    public record ReadLine() : CommandLineEffect(), IEffect<string>
    {
        public string? Result { get; set; }

        public override void Execute()
        {
            Result = Console.ReadLine();
        }
    }

    public record WriteLine(string Text) : CommandLineEffect()
    {
        public override void Execute()
        {
            Console.WriteLine(Text);
        }
    }

    public record Call<T>(CommandLineCoroutine<T> Program) : CommandLineEffect(), IEffect<T>
    {
        public T? Result { get; set; }

        public override void Execute()
        {
            foreach (var i in Program)
            {
                i.Execute();
            }

            Result = Program.Result;
        }
    }

    private CommandLineEffect() { }

    public abstract void Execute();
}

namespace Coroutine;

public static class CommandLineInterpreter
{
    public static void Interpret(CommandLineCoroutine program)
    {
        foreach (var i in program)
        {
            program.NextValue = i switch
            {
                CommandLineSink.ReadLine => InterpretReadLine(),
                CommandLineSink.WriteLine w => InterpretWriteLine(w),
                _ => throw new InvalidOperationException(),
            };
        }
    }

    private static CommandLineSource InterpretReadLine()
    {
        var text = Console.ReadLine();
        return new CommandLineSource.ReadLine(text);
    }

    private static CommandLineSource InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return new CommandLineSource.WriteLine();
    }
}

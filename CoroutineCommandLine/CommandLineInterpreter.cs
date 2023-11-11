namespace CoroutineCommandLine;

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
                _ => null,
            };
        }
    }

    private static CommandLineSource InterpretReadLine()
    {
        return new CommandLineSource.ReadLine(Console.ReadLine());
    }

    private static CommandLineSource InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return new CommandLineSource.WriteLine();
    }
}

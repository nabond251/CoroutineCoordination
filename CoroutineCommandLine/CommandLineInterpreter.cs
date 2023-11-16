namespace CoroutineCommandLine;

using CoroutineUtilities;

public static class CommandLineInterpreter
{
    public static void Interpret(CommandLineCoroutine program)
    {
        foreach (var i in program)
        {
            program.NextValue = i switch
            {
                CommandLineSink.ReadLine r => InterpretReadLine(r),
                CommandLineSink.WriteLine w => InterpretWriteLine(w),
                _ => throw new InvalidOperationException(),
            };
        }
    }

    private static CommandLineSource InterpretReadLine(
        CommandLineSink.ReadLine r)
    {
        r.Program.NextValue = Console.ReadLine();
        return new CommandLineSource.ReadLine(r.Program.NextValue);
    }

    private static CommandLineSource InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return new CommandLineSource.WriteLine();
    }
}

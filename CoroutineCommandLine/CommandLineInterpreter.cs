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
        FuncInterpreter<string?>.Interpret(r.Program);
        return new CommandLineSource.ReadLine(r.Program.NextValue);
    }

    private static CommandLineSource InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return new CommandLineSource.WriteLine();
    }
}

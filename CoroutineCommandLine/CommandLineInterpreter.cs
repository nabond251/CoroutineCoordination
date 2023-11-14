namespace CoroutineCommandLine;

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
                _ => null,
            };
        }
    }

    private static CommandLineSource InterpretReadLine(
        CommandLineSink.ReadLine r)
    {
        ReadLineInterpreter.Interpret(r.Program);
        return new CommandLineSource.ReadLine(r.Program.NextValue);
    }

    private static CommandLineSource InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return new CommandLineSource.WriteLine();
    }
}

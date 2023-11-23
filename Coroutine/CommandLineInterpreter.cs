using System.Threading.Channels;

namespace Coroutine;

public static class CommandLineInterpreter
{
    public static T? Interpret<T>(CommandLineCoroutine<T> program)
    {
        foreach (var i in program)
        {
            _ = i switch
            {
                CommandLineSink.ReadLine r => InterpretReadLine(r),
                CommandLineSink.WriteLine w => InterpretWriteLine(w),
                _ => throw new InvalidOperationException(),
            };
        }

        return program.Result;
    }

    private static Unit InterpretReadLine(
        CommandLineSink.ReadLine r)
    {
        r.Result = Console.ReadLine();
        return new Unit();
    }

    private static Unit InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return new Unit();
    }
}

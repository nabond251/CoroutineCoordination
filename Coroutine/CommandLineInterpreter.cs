using System.Threading.Channels;

namespace Coroutine;

public static class CommandLineInterpreter
{
    public static void Interpret(
        CommandLineCoroutine program,
        ChannelWriter<CommandLineSource> nextWriter)
    {
        foreach (var i in program)
        {
            var next = i switch
            {
                CommandLineSink.ReadLine => InterpretReadLine(),
                CommandLineSink.WriteLine w => InterpretWriteLine(w),
                _ => throw new InvalidOperationException(),
            };

            if (next is not null)
            {
                nextWriter.TryWrite(next);
            }
        }
    }

    private static CommandLineSource? InterpretReadLine()
    {
        var text = Console.ReadLine();
        return new CommandLineSource.ReadLine(text);
    }

    private static CommandLineSource? InterpretWriteLine(
        CommandLineSink.WriteLine w)
    {
        Console.WriteLine(w.Text);
        return null;
    }
}

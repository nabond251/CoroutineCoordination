namespace CoroutineCommandLine;

public static class ReadLineInterpreter
{
    public static void Interpret(ReadLineCoroutine program)
    {
        foreach (var i in program)
        {
            program.NextValue = i switch
            {
                ReadLineSink.ReadLine => InterpretReadLine(),
                _ => null,
            };
        }
    }

    private static ReadLineSource InterpretReadLine()
    {
        return new ReadLineSource.ReadLine(Console.ReadLine());
    }
}

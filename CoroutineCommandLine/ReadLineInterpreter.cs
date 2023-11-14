namespace CoroutineCommandLine;

public static class ReadLineInterpreter
{
    public static void Interpret(ReadLineCoroutine program)
    {
        foreach (var i in program)
        {
            program.NextValue = i switch
            {
                Unit => InterpretReadLine(),
                _ => null,
            };
        }
    }

    private static string? InterpretReadLine()
    {
        return Console.ReadLine();
    }
}

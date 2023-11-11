namespace CoroutineCommandLine;

public static class CommandLineInterpreter
{
    public static void Interpret(IEnumerable<string?> program)
    {
        foreach (var i in program)
        {
            if (i is null)
            {
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}

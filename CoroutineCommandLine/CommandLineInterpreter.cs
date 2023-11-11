namespace CoroutineCommandLine;

public static class CommandLineInterpreter
{
    public static void Interpret(CommandLineCoroutine program)
    {
        foreach (var i in program)
        {
            if (i is null)
            {
                program.NextValue = Console.ReadLine();
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}

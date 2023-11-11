namespace CoroutineCommandLine;

public static class CommandLineInterpreter
{
    public static void Interpret(CommandLineCoroutine program)
    {
        foreach (var i in program)
        {
            if (i is CommandLineSink.ReadLine)
            {
                program.NextValue = new CommandLineSource.ReadLine(
                    Console.ReadLine());
            }
            else if (i is CommandLineSink.WriteLine w)
            {
                Console.WriteLine(w.Text);
            }
        }
    }
}

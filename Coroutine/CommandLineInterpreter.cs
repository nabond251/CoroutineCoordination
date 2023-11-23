namespace Coroutine;

public static class CommandLineInterpreter
{
    public static T? Interpret<T>(CommandLineCoroutine<T> program)
    {
        foreach (var i in program)
        {
            i.Execute();
        }

        return program.Result;
    }
}

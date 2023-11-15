namespace CoroutineCommandLine;

public static class FuncInterpreter<T>
{
    public static void Interpret(IFuncCoroutine<T> program)
    {
        foreach (var i in program)
        {
            program.NextValue = i switch
            {
                Unit => InterpretFunc(program.Func),
                _ => throw new InvalidOperationException(),
            };
        }
    }

    private static T? InterpretFunc(Func<T> func)
    {
        return func();
    }
}

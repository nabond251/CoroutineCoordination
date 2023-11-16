using CoroutineCommandLine;
using CoroutineCoordination;
using CoroutineUtilities;

CommandLineInterpreter.Interpret(
    new HelloCommandLine(
        new FuncCoroutine<string?>(
            Console.ReadLine)));

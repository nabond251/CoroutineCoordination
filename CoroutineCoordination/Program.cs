using CoroutineCommandLine;
using CoroutineCoordination;

CommandLineInterpreter.Interpret(
    new HelloCommandLine(
        new FuncCoroutine<string?>(
            Console.ReadLine)));

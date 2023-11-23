using Coroutine;
using Coroutine.Coordination;

Console.WriteLine(
    CommandLineInterpreter.Interpret(
        new ReadReservationRequestCoroutine()));

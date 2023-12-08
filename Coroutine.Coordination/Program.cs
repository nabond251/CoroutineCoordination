using Coroutine;
using Coroutine.Coordination;

Console.WriteLine(
    (await Interpreter.InterpretAsync(
        new ReadReservationRequestCoroutine())).Single());

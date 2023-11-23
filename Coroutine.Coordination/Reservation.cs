namespace Coroutine.Coordination;

public record Reservation(
    DateTime Date,
    string Name,
    string Email,
    int Quantity);

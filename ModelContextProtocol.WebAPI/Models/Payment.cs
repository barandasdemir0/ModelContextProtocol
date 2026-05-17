public record Payment(
    string Id,
    string Company,
    string Reason,
    DateOnly DueDate,
    decimal Amount);
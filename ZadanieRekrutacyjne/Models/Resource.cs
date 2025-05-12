namespace ZadanieRekrutacyjne.Models;
public abstract record BasicResoruce;
public class Resource<T>(T data) where T : BasicResoruce;



public record struct Slot(DateTime start, DateTime end);
public record Appointment(Guid Id, Slot Slot, Person Patient) : BasicResoruce;
public record Visit (Guid Id, Person Patient) : BasicResoruce;

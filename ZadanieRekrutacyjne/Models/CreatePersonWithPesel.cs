namespace ZadanieRekrutacyjne.Models;

public class CreatePersonWithPesel
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } 
    public string Surname { get; set; }
    public string Pesel { get; set; } 
    public string Street { get; set; }
    public string NumberOfHouse { get; set; }
    public string ZipCode { get; set; } 
    public string City { get; set; }
}

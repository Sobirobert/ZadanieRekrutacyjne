using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ZadanieRekrutacyjneContext(DbContextOptions<ZadanieRekrutacyjneContext> options) : DbContext(options)
{
    public DbSet<Simple> SimplePerson { get; set; }
    public DbSet<WithPesel> PersonWithPesel { get; set; }
}

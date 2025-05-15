using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ZadanieRekrutacyjneContext : DbContext
{
    //private readonly UserResolverService _userResolverService;
    public ZadanieRekrutacyjneContext(DbContextOptions<ZadanieRekrutacyjneContext> options/*, UserResolverService userService*/)
        : base(options)
    {
        //_userResolverService = userService;
    }

    public DbSet<Person> SimplePerson { get; set; }
    public DbSet<WithPesel> PersonWithPesel { get; set; }
}

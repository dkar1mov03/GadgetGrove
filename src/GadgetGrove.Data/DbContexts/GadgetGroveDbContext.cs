using Microsoft.EntityFrameworkCore;

namespace GadgetGrove.Data.DbContexts;

public class GadgetGroveDbContext : DbContext
{
    public GadgetGroveDbContext(DbContextOptions<GadgetGroveDbContext> options) : base(options)
    { }
}

using System.Transactions;

using Microsoft.EntityFrameworkCore;

namespace BudgetLens.Data.Postgres;

public class PgContext(DbContextOptions<PgContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
}

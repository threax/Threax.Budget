using Microsoft.EntityFrameworkCore;

namespace Budget.Database
{
    public partial class AppDbContext
    {
        public DbSet<EntryEntity> Entrys { get; set; }
    }
}

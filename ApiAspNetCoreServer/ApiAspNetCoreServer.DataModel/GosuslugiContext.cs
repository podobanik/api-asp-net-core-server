using ApiAspNetCoreServer.DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAspNetCoreServer.DataModel
{
    public class GosuslugiContext : DbContext
    {
        public GosuslugiContext(DbContextOptions<GosuslugiContext> options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<AvailableDocument> AvailableDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Client>().HasOne(x => x.Document).WithOne().OnDelete(DeleteBehavior.Cascade);
            //base.OnModelCreating(builder);
        }
    }
}
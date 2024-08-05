using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Npgsql;

namespace Infrastructure.Persistence
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is AuditEntity && (
              e.State == EntityState.Added
              || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditEntity)entityEntry.Entity).LastModifiedDate = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditEntity)entityEntry.Entity).CreationDate = DateTime.UtcNow;
                }
            }
        }

        public async Task<T> ExecuteFunction<T>(string command)
        {
            NpgsqlConnection connection = (NpgsqlConnection)Database.GetDbConnection();

            if (connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Close();
            }

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand(command, connection))
            {
                T result = (T)await cmd.ExecuteScalarAsync();
                return result;
            }

        }
    }
}

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

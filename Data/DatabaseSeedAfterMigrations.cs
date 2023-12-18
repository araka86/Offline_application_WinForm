using CartrigeAltstar.Model;
using System.Data.Entity;
using System.Linq;

namespace CartrigeAltstar.Data
{
    public class DatabaseSeedAfterMigrations
    {
        private ContexAltstar contexAltstar;

        public DatabaseSeedAfterMigrations()
        {
            contexAltstar = new ContexAltstar(); // Инициализируйте ваш контекст данных
        }

        /// check table data
        public void CheckAndPopulateData()
        {
            foreach (var tableName in GetTableNamesInDbContext())
            {
                if (!DatabaseHasData(tableName))
                {
                    PopulateData(tableName);
                }
            }
        }

        //get table
        private IQueryable<string> GetTableNamesInDbContext()
        {
            return contexAltstar.GetType()
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.Name)
                .AsQueryable();
        }


        private bool DatabaseHasData(string tableName)
        {
            var sql = $"SELECT COUNT(*) FROM {tableName}";
            var count = contexAltstar.Database.SqlQuery<int>(sql).SingleOrDefault();
            return count > 0;
        }

        //fill table if data exist
        private void PopulateData(string tableName)
        {
            switch (tableName)
            {
                case "Users":
                    AddInitialData(new User
                    {
                        FirstName = "Admin",
                        LasttName = "Admin",
                        LoginId = "12345",
                        UniqId = 1234567890,
                        Role = "SuperAdmin",
                        Password = "12345"
                    });
                    break;              
            }
        }

        private void AddInitialData<T>(T entity) where T : class
        {
            contexAltstar.Set<T>().Add(entity);
            contexAltstar.SaveChanges();
        }
    }
}

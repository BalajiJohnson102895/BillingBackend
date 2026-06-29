using BillingBackend.Interfaces;
using BillingBackend.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BillingBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }



        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("BillingDB"));
        }

        private SqlConnection CreateConnection() => GetConnection();

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            const string sql = @"
                SELECT ProductId, ProductCode, ProductDescription,
                       PriceInclGST, GstPercent, CaseQuantity,
                       HsnCode, UnitOfMeasure,
                       FORMAT(CreatedOn, 'yyyy-MM-dd HH:mm:ss') AS CreatedOn
                FROM Products 
                ORDER BY ProductCode";

            using var conn = CreateConnection();
            return await conn.QueryAsync<Product>(sql);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT ProductId, ProductCode, ProductDescription,
                       PriceInclGST, GstPercent, CaseQuantity,
                       HsnCode, UnitOfMeasure,
                       FORMAT(CreatedOn, 'yyyy-MM-dd HH:mm:ss') AS CreatedOn
                FROM Products
                WHERE ProductId = @ProductId";

            using var conn = CreateConnection();
            return await conn.QuerySingleOrDefaultAsync<Product>(sql, new { ProductId = id });
        }

    }
}

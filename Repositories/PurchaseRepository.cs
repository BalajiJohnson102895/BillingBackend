using BillingBackend.Interfaces;
using Microsoft.Data.SqlClient;
using static BillingBackend.Models.Purchase;

namespace BillingBackend.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly string _connectionstring;
        public PurchaseRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddPurchaseAsync()
        {
            using var connection = new SqlConnection(_connectionstring);
            await connection.OpenAsync();
            using var transaction = connection.BeginTransaction();
            try
            {
                transaction.Commit();
                return 1;
            }
            catch (Exception ex) 
            {
                transaction.Rollback();
                throw;
            }

        }

    }
}

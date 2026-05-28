using BillingBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BillingBackend.Models.Purchase;

namespace BillingBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        public IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

    }
}

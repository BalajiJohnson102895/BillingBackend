namespace BillingBackend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public decimal PriceInclGST { get; set; }
        public decimal GstPercent { get; set; }
        public int CaseQuantity { get; set; }
        public string? HsnCode { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? CreatedOn { get; set; }
    }
}

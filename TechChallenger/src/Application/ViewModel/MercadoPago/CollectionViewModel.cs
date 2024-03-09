using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MercadoPago
{
    public class CollectionViewModel
    {
        public long Id { get; set; }
        public string? SiteId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime MoneyReleaseDate { get; set; }
        public DateTime LastModified { get; set; }
        public PayerViewModel? Payer { get; set; }
        public string? OrderId { get; set; }
        public string? ExternalReference { get; set; }
        public string? MerchantOrderId { get; set; }
        public string? Reason { get; set; }
        public string? CurrencyId { get; set; }
        public int TransactionAmount { get; set; }
        public double NetReceivedAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal CouponAmount { get; set; }
        public decimal CouponFee { get; set; }
        public decimal FinanceFee { get; set; }
        public decimal DiscountFee { get; set; }
        public string? CouponId { get; set; }
        public string?Status { get; set; }
        public string?StatusDetail { get; set; }
        public int Installments { get; set; }
        public int IssuerId { get; set; }
        public int InstallmentAmount { get; set; }
        public string? DeferredPeriod { get; set; }
        public string?PaymentType { get; set; }
        public string?PaymentMethodId { get; set; }
        public string? Marketplace { get; set; }
        public string?OperationType { get; set; }
        public string? TransactionOrderId { get; set; }
        public string?StatementDescriptor { get; set; }
        public CardholderViewModel? Cardholder { get; set; }
        public string?AuthorizationCode { get; set; }
        public int MarketplaceFee { get; set; }
        public string?LastFourDigits { get; set; }
        public object? DeductionSchema { get; set; }
        public List<object>? Refunds { get; set; }
        public int AmountRefunded { get; set; }
        public object? LastModifiedByAdmin { get; set; }
        public string?ApiVersion { get; set; }
        public object? ConceptId { get; set; }
        public int ConceptAmount { get; set; }
        public CollectorViewModel? Collector { get; set; }
    }
}

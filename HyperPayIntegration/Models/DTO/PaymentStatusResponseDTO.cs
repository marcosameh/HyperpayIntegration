namespace HyperPayIntegration.Models.DTO
{
    public class PaymentStatusResponseDTO
    {
        public string Id { get; set; }
        public string PaymentType { get; set; }
        public string PaymentBrand { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Descriptor { get; set; }
        public ResultData Result { get; set; }
        public ResultDetails ResultDetails { get; set; }
        public Card Card { get; set; }
        public Customer Customer { get; set; }
        public ThreeDSecure ThreeDSecure { get; set; }
        public CustomParameters CustomParameters { get; set; }
        public Risk Risk { get; set; }
        public string BuildNumber { get; set; }
        public string Timestamp { get; set; }
        public string Ndc { get; set; }
    }

    

    public class ResultDetails
    {
        public string RiskStatusCode { get; set; }
        public string ResponseCode { get; set; }
        public string ClearingInstituteName { get; set; }
        public string RequestId { get; set; }
        public string RiskResponseCode { get; set; }
       
        public string Action { get; set; }
        public string OrderId { get; set; }
    }

    public class Issuer
    {
        public string Bank { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
    }

    public class Card
    {
        public string Bin { get; set; }
        public string BinCountry { get; set; }
        public string Last4Digits { get; set; }
        public string Holder { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public Issuer Issuer { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string MaxPanLength { get; set; }
        public string RegulatedFlag { get; set; }
    }

    public class Customer
    {
        public string Ip { get; set; }
        public string IpCountry { get; set; }
    }

    public class ThreeDSecure
    {
        public string Eci { get; set; }
    }

    public class CustomParameters
    {
        public string SHOPPER_EndToEndIdentity { get; set; }
        public string CTPE_DESCRIPTOR_TEMPLATE { get; set; }
    }

    public class Risk
    {
        public string Score { get; set; }
    }


}
    


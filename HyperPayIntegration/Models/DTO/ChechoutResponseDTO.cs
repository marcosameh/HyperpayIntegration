﻿namespace HyperPayIntegration.Models.DTO
{
    public class CheckoutResponseDTO
    {
        public ResultData Result { get; set; }
        public string BuildNumber { get; set; }
        public string Timestamp { get; set; }
        public string Ndc { get; set; }
        public string Id { get; set; }

    }
   
}

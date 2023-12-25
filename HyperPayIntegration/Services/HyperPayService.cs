using HyperPayIntegration.Infrastructure;
using HyperPayIntegration.Models.DTO;
using HyperPayIntegration.Services.IService;
using Newtonsoft.Json;
using System.Net;

namespace HyperPayIntegration.Services
{
    public class HyperPayService: IHyperPayService
    {
        private readonly IConfiguration configuration;
        private string baseApiUrl;
        private string authorizationToken;

        public HyperPayService(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            authorizationToken = configuration["HyperPayAuthorizationToken"];
            baseApiUrl = configuration["HyperPayGatewayURL"];
           
        }
        public async Task<Result<CheckoutResponseDTO>> Checkout(CheckoutRequestDTO checkoutRequest)
        {
            try
            {
                var apiUrl = baseApiUrl + "/v1/checkouts"; // Use the correct endpoint URL
                using (var httpClient = new HttpClient())
                {
                    var requestData = new Dictionary<string, string>
            {
                { "entityId", checkoutRequest.EntityId },
                { "amount", checkoutRequest.Amount.ToString("0.00") },
                { "currency", checkoutRequest.Currency },
                { "paymentType", checkoutRequest.PaymentType },
            };

                    httpClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);
                    var content = new FormUrlEncodedContent(requestData);

                    // Use apiUrl instead of baseApiUrl here
                    var httpResponse = await httpClient.PostAsync(apiUrl, content);

                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                    {
                        var errorMessage = $"Checkout failed with status code {httpResponse.StatusCode}";
                        return Result.Fail<CheckoutResponseDTO>(errorMessage);
                    }

                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var checkoutResponse = JsonConvert.DeserializeObject<CheckoutResponseDTO>(responseContent);
                    return Result.Ok(checkoutResponse);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred during checkout: {ex.Message}. Inner Exception: {ex.InnerException?.Message}";
                return Result.Fail<CheckoutResponseDTO>(errorMessage);
            }
        }

        public async Task<Result<PaymentStatusResponseDTO>> PaymentStatus(string checkoutId)
        {
            try
            {
                string entityId = "entityId=8a8294174b7ecb28014b9699220015ca";
                var apiUrl = $"{baseApiUrl}/v1/checkouts/{checkoutId}/payment?"+entityId;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                    var httpResponse = await httpClient.GetAsync(apiUrl);

                    if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        var errorMessage = $"Payment status check failed with status code {httpResponse.StatusCode}";
                        return Result.Fail<PaymentStatusResponseDTO>(errorMessage);
                    }

                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var paymentStatusResponse = JsonConvert.DeserializeObject<PaymentStatusResponseDTO>(responseContent);
                    return Result.Ok(paymentStatusResponse);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred during payment status check: {ex.Message}. Inner Exception: {ex.InnerException?.Message}";
                return Result.Fail<PaymentStatusResponseDTO>(errorMessage);
            }
        }
    }
}

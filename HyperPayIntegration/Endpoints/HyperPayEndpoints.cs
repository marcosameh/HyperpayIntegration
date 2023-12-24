using HyperPayIntegration.Endpoints;
using HyperPayIntegration.Models.DTO;
using HyperPayIntegration.Services.IService;
namespace HyperPayIntegration.Endpoints
{
    public static class HyperPayEndpoints
    {
        public static void ConfigureHyperPayEndpoints(this WebApplication app)
        {
          

            app.MapPost("/hyperpay/checkout", async (CheckoutRequestDTO checkoutRequest, IHyperPayService hyperPayService) =>
            {
                var result = await hyperPayService.Checkout(checkoutRequest);

                if (result.IsSuccess)
                {
                    return Results.Ok(result.Value);
                }
                else
                {
                    return Results.BadRequest(result.Error);
                }
            });
            app.MapPost("/hyperpay/paymentstatus", async (string checkoutId, IHyperPayService hyperPayService) =>
            {
                var result = await hyperPayService.PaymentStatus(checkoutId);

                if (result.IsSuccess)
                {
                    return Results.Ok(result.Value);
                }
                else
                {
                    return Results.BadRequest(result.Error);
                }
            });
        }
    }
}

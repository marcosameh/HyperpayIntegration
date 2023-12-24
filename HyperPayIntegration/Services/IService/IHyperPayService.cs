using HyperPayIntegration.Infrastructure;
using HyperPayIntegration.Models.DTO;

namespace HyperPayIntegration.Services.IService
{
    public interface IHyperPayService
    {
        Task<Result<CheckoutResponseDTO>> Checkout(CheckoutRequestDTO checkoutRequest);
    }
}

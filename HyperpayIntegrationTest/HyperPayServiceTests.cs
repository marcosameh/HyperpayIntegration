using HyperPayIntegration.Models.DTO;
using HyperPayIntegration.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class HyperPayServiceTests
{
    [Fact]
    public async Task Checkout_Should_Return_Result()
    {
        // Arrange
        var configuration = new Mock<IConfiguration>();
        configuration.Setup(c => c["HyperPayAuthorizationToken"]).Returns("Bearer OGE4Mjk0MTc0YjdlY2IyODAxNGI5Njk5MjIwMDE1Y2N8c3k2S0pzVDg=");
        configuration.Setup(c => c["HyperPayGatewayURL"]).Returns("https://eu-test.oppwa.com");

        var hyperPayService = new HyperPayService(configuration.Object);

        // Act
        var result = await hyperPayService.Checkout(new CheckoutRequestDTO
        {
            EntityId = "8a8294174b7ecb28014b9699220015ca",
            Amount = 100,
            Currency = "EUR",
            PaymentType = "DB"
        });

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public async Task PaymentStatus_Should_Return_Result()
    {
        // Arrange
        var configuration = new Mock<IConfiguration>();
        configuration.Setup(c => c["HyperPayAuthorizationToken"]).Returns("Bearer OGE4Mjk0MTc0YjdlY2IyODAxNGI5Njk5MjIwMDE1Y2N8c3k2S0pzVDg=");
        configuration.Setup(c => c["HyperPayGatewayURL"]).Returns("https://eu-test.oppwa.com");

        var hyperPayService = new HyperPayService(configuration.Object);

        // Act
        var result = await hyperPayService.PaymentStatus("B8C83D76F4FFD773724192A4D5E07C6D.uat01-vm-tx02");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }
}

namespace Vinder.Comanda.Internal.Contracts.Transport.External.AbacatePay;

public sealed record PixChargeScheme
{
    public string Id { get; init; } = default!;
    public string Status { get; init; } = default!;

    public decimal Amount { get; init; } = default!;
    public decimal PlatformFee { get; init; } = default!;

    public string BrCode { get; init; } = default!;
    public string BrCodeBase64 { get; init; } = default!;

    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
}
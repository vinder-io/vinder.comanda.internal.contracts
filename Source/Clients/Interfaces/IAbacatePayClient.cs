using Vinder.Comanda.Internal.Contracts.Transport.External.AbacatePay;

namespace Vinder.Comanda.Internal.Contracts.Clients.Interfaces;

public interface IAbacatePayClient
{
    public Task<Result<PixChargeSessionScheme>> CreateChargeSessionAsync(
        PixChargeScheme parameters,
        CancellationToken cancellation = default
    );
}
using System.Net.Http.Json;
using System.Text.Json;

using Vinder.Comanda.Internal.Contracts.Clients.Interfaces;
using Vinder.Comanda.Internal.Contracts.Transport.External.AbacatePay;

namespace Vinder.Comanda.Internal.Contracts.Clients;

public sealed class AbacatePayClient(HttpClient httpClient) : IAbacatePayClient
{
    private readonly JsonSerializerOptions serializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    public async Task<Result<PixChargeSessionScheme>> CreateChargeSessionAsync(
        PixChargeScheme parameters, CancellationToken cancellation = default)
    {
        var response = await httpClient.PostAsJsonAsync("pixQrCode/create", parameters, cancellation);
        var content = await response.Content.ReadAsStringAsync(cancellation);

        if (!response.IsSuccessStatusCode)
        {
            return Result<PixChargeSessionScheme>.Failure(AbacatePayErrors.OperationFailed);
        }

        var session = JsonSerializer.Deserialize<Response<PixChargeSessionScheme>>(content, serializerOptions);
        if (session is null)
        {
            return Result<PixChargeSessionScheme>.Failure(AbacatePayErrors.InvalidContent);
        }

        return Result<PixChargeSessionScheme>.Success(session.Data);
    }
}
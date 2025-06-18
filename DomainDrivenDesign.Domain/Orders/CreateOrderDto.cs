using DomainDrivenDesign.Domain.Products;

namespace DomainDrivenDesign.Domain.Orders;

public sealed record CreateOrderDto(
    Guid ProductId,
    int Quantity,
    decimal Amount,
    string Currency,
    Product product);

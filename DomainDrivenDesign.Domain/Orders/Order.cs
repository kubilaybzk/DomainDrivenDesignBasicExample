using DomainDrivenDesign.Domain.Abstractions;

namespace DomainDrivenDesign.Domain.Orders;

public sealed class Order: Entity
{
    public Order(Guid CreatedTimeAssignedId) : base(CreatedTimeAssignedId)
    {
    }

    public string OrderNumver { get; set; }
    public DateTime CreateDate { get; set; }
    public OrderStatusEnum Status { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}




namespace DomainDrivenDesign.Domain.Orders;

public sealed class Order
{
    public Guid Id { get; set; }
    public string OrderNumver { get; set; }
    public DateTime CreateDate { get; set; }
    public OrderStatusEnum Status { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}




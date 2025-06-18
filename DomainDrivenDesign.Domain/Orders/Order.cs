﻿using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Shared.DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders;

public sealed class Order : Entity
{
    public Order(Guid id, string orderNumber, DateTime createdDate, OrderStatusEnum status) : base(id)
    {
        OrderNumber = orderNumber;
        CreatedDate = createdDate;
        Status = status;
        OrderLines = new List<OrderLine>();
    }

    public string OrderNumber { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public ICollection<OrderLine> OrderLines { get; private set; }
    public void CreateOrderLine(List<CreateOrderDto> createOrderDtos)
    {
        foreach (var item in createOrderDtos)
        {
            if (item.Quantity < 1)
            {
                throw new ArgumentException("Sipariş adedi 1 den az olamaz!");
            }

            //kalan iş kuralları

            OrderLine orderLine = new(
                Guid.NewGuid(),
                Id,
                item.ProductId,
                item.Quantity,
                new(item.Amount, Currency.FromCode(item.Currency)));

            OrderLines.Add(orderLine);
            orderLine.AddProduct(item.product); // Product nesnesini OrderLine'a ekliyoruz
        }
    }
    public void RemoveOrderLine(Guid orderLineId)
    {
        var orderLine = OrderLines.FirstOrDefault(p => p.Id == orderLineId);
        if (orderLine is null)
        {
            throw new ArgumentException("Silmek istediğiniz sipariş kalemi bulunamadı!");
        }
       

        OrderLines.Remove(orderLine);
    }
}
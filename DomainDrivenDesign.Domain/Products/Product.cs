using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;

namespace DomainDrivenDesign.Domain.Products
{
    public sealed class Product: Entity
    {
        public Product(Guid CreatedTimeAssignedId) : base(CreatedTimeAssignedId)
        {
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Shared.DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Products
{
    public sealed class Product: Entity
    {
        public Product(Guid id, Name name, int quantity, Money price, Guid categoryId, Category category) : base(id)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            CategoryId = categoryId;
            Category = category;
        }
        public Name Name { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public void ChangeName(Name name)
        {
            Name = name;
        }
        public void ChangeQuantity(int quantity)
        {
            
            Quantity = quantity;
        }
        public void ChangePrice(Money price)
        {
            
            Price = price;
        }
        public void ChangeCategory(Category category)
        {
           
            Category = category;
            CategoryId = category.Id; // Assuming Category has an Id property
        }
        public void UpdateProduct(string name, int quantity, decimal amount, string currency, Guid categoryId)
        {
            Name = new(name);
            Quantity = quantity;
            Price = new(amount, Currency.FromCode(currency));
            CategoryId = categoryId;
        }
    }
}

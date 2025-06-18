using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Categories
{
    public sealed class Category: Entity
    {
        public Category(Guid CreatedTimeAssignedId,Name name, ICollection<Product> products):base(CreatedTimeAssignedId)
        {
            Name = name;
            Products = products;
        }
        public Name Name { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public void ChangeName(Name name)
        {
            Name = name;
        }
    }
}


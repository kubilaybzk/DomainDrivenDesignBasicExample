using DomainDrivenDesign.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
    public sealed class User : Entity
    {
        public User(Guid CreatedTimeAssignedId) : base(CreatedTimeAssignedId)
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }
    }

   
}

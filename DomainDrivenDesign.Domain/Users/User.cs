using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
    public sealed class User : Entity
    {
        public User(Guid Id,Name name, Password password, Email email, AddressRecord address):base(Id)
        {
            Name = name;
            Password = password;
            Email = email;
            Address = address;
        }

        public Name Name { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }
        public AddressRecord Address { get; private set; } // Address sınıfını burada kullanıyoruz
        public void ChangeName(Name name)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name), "Name cannot be null");

             
            Name = name;
        }
        public void ChangePassword(Password password)
        {
   
            Password = password;
        }
        public void ChangeEmail(Email email)
        {
            Email = email;
        }
        public void ChangeAddress(string country, string city, string street, string postalCode, string fullAddress)
        {
            Address = new(country, city, street, fullAddress, postalCode);
        }
        public void ChangeUser(Name name, Password password, Email email, AddressRecord address)
        {
            Name = name;
            Password = password;
            Email = email;
            Address = address;
        }
}
}
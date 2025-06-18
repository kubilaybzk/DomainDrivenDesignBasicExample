using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Shared.DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using System;

namespace SmallTest.DomainDrivenDesign.SmallTest
{
    public sealed class Address
    {
        public string Street { get; }
        public string City { get; }
        public string Country { get; }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Address other)
                return false;

            return Street == other.Street &&
                   City == other.City &&
                   Country == other.Country;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, Country);
        }
    }

    public class ExampleClass
    {
        public Guid Id { get; }

        public ExampleClass(Guid id)
        {
            Id = id;
        }
    }

    public class Program
    {
        public static void Main()
        {
            //Guid oneTimeCreatedGuid = Guid.NewGuid();
            //Guid oneTimeCreatedGuid2 = Guid.NewGuid();
            //ExampleClass example1 = new(oneTimeCreatedGuid);
            //ExampleClass example2 = new(oneTimeCreatedGuid);

            //Console.WriteLine(example1.Id == example2.Id);
            //Console.WriteLine(example1.Equals(example2));
            //Console.WriteLine(example1 == example2);

            //Address address1 = new Address("Gül Sk", "İstanbul", "Türkiye");
            //Address address2 = new Address("Gül Sk", "İstanbul", "Türkiye");
            //Console.WriteLine("Address bilgiler");
            //Console.WriteLine(address1.Equals(address2)); // True – içerik aynı


            //Id değerleri farklı
            //User user1 = new(Guid.NewGuid(), new("Kubilay"), new("1233131"), new("kubilay@bozak.dev"), new("Türkiye", "İstanbul", "Test", "Test Full Address", "3124"));
            //User user2 = new(Guid.NewGuid(), new("Kubilay"), new("22222222222"), new("kubilay2@bozak2.dev"), new("Türkiye2", "İstanbul", "Test", "Test Full Address", "3124"));
            //Id değerleri aynı
            //User user3 = new(oneTimeCreatedGuid, new("Kubilays"), new("1233131"), new("kubilay@bozak.dev"), new("Türkiye", "İstanbul", "Test", "Test Full Address", "3124"));
            //User user4 = new(oneTimeCreatedGuid, new("Kubilay"), new("22222222222"), new("kubilay2@bozak2.dev"), new("Türkiye", "İstanbul", "Test", "Test Full Address", "3124"));


            //Console.WriteLine(user1.Name.Equals(user2.Name) + "  Name değerleri user1 ve user 2");         //True döner Value Object'ler ve içerikleri aynı
            //Console.WriteLine(user1.Address.Equals(user2.Address) + "  Address değerleri user1 ve user 2");   //False döner içerikleri farklı 
            //Console.WriteLine(user1.Equals(user2) + "  Userdeğerleri user1 ve user2");                   //False döner çünkü User sınıfı Entity'dir ve Id'leri farklıdır.


            //Console.WriteLine(user3.Name.Equals(user4.Name) + "  Name değerleri user1 ve user 2");         //True döner Value Object'ler ve içerikleri aynı
            //Console.WriteLine(user3.Address.Equals(user4.Address) + "  Address değerleri user1 ve user 2");   //True döner içerikleri aynı
            //Console.WriteLine(user3.Equals(user4) + "   Userdeğerleri user1 ve user2");                   //True döner çünkü User sınıfı Entity'dir ve Id'leri aynıdır.



            User kubilay = new(Guid.NewGuid(), new("Kubilay"), new("Aa123456."), new("Selamlarrr@fas.com"), new("Türkiye", "İstanbul", "Test", "Test Full Address", "3124"));


            Category elektronik = new(Guid.NewGuid(), new("Elektronik"), new List<Product>());
            Product product = new(Guid.NewGuid(), new("Test Product"), 10, new(100, Currency.FromCode("TRY")), elektronik.Id, elektronik);
            elektronik.Products.Add(product);
            foreach (var p in elektronik.Products)
            {
                Console.WriteLine(p.Name);
            }

            foreach (var p in product.Category.Products)
            {
                Console.WriteLine(p.Name);
            }

            Order order = new(Guid.NewGuid(), "ORD12345", DateTime.Now, OrderStatusEnum.AwaitingApproval);
            
            order.CreateOrderLine(new List<CreateOrderDto>
            {
                new(product.Id,2,200,"TRY",product)

            });

           
            foreach (var orderLine in order.OrderLines)
            {
                Console.WriteLine($"Order Line Product ID: {orderLine.ProductId}, Quantity: {orderLine.Quantity}, Amount: {orderLine.Price.Amount} {orderLine.Price.Currency.Code} , Prodcur {orderLine.Product.Name}");
            }




        }
    }
}

using DomainDrivenDesign.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Abstractions
{
    //Sadece Kalıtım alınsın istiyoruz kendi başına bir oluşum olmasın
    //Bu yüzden abstract olarak tanımlıyoruz
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; init; } //Inıt property olarak tanımladık ki sadece constructor'da atama yapılabilsin ve değiştirilemesin
        protected Entity(Guid CreatedTimeAssignedId)
        {
            this.Id = CreatedTimeAssignedId;
        }
        //Equals metodunu override ettik çünkü Entity sınıfından türetilen sınıfların karşılaştırılmasını istiyoruz
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not Entity entity)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return entity.Id == Id;
        }
        //GetHashCode metodunu override ettik çünkü Entity sınıfından türetilen Array veya List gibi koleksiyonlarda kullanılacaksa, bu metodun da doğru çalışması gerekiyor.
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        // IEquatable<Entity> arayüzünü implement ettik çünkü Entity sınıfından türetilen sınıfların karşılaştırılmasını istiyoruz
        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other is not Entity entity)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return entity.Id == Id;
        }

        /* 
         Burada ufak bir dipnot belirtmek istiyorum.
         Burada kullandığımız IEquatable<Entity> arayüzü ile kendi oluşturduğumuz
         equals methodundan daha biraz daha advance bir method.
           Fark Şu : - Kendi override ettiğimiz method Unboxing yapıyor yani basitçe objeyi tipe çeviriyor,
                         Tipe göre kontrol etme işlemi yapıyor biraz daha kötü performans sağlıyor.
                     - İmplement ettiğimiz method ise Unboxing yapmıyor.
         
         */


    }



}










public class ExampleClass : Entity
{
    public ExampleClass(Guid CreatedTimeAssignedId) : base(CreatedTimeAssignedId)
    {
    }
}

public class TestRunner
{
    public void main()
    {

        Guid oneTimeCreatedGuid = Guid.NewGuid();

        ExampleClass example1 = new(oneTimeCreatedGuid);

        ExampleClass example2 = new(oneTimeCreatedGuid);

        Console.WriteLine(example1.Id == example2.Id);

        Console.WriteLine(example1.Equals(example2));  
    }
}

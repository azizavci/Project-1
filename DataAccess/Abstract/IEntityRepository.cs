using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //burada bir back end tasarımı yapmaktayız
    //bu tasarımda belli kurallar oluşturmak durumundayız
    //o yüzden bizim interface imize gönderilecek olan T parametresi
    //için sınırlar belirlemek istersek:
    //örneğin herkes kendi istediği T yi yazamasın.T ye sadece
    //veritabanı nesneleri gönderilebilsin.bu sınırlamalara 
    //GERNERIC CONSTRAINT denir.
    //class: demek sadece class yazılabilir demek değil.
    //referans tip yazılabilir demek
    //where T:class bu şekilde T ye istediğimiz referans tipi gönderebiliriz.
    //ancak bu kısıtlama da yeterli değildir
    //IEntity tüm vt nesnelerimizin ortak özelliğidir
    //new() demek new lenemez olmalıdır.yani IEntity de olamaz
    public interface IEntityRepository<T> where T:class,IEntity, new()//T bir referans tip olmalı ve ya IEntity ya da IEntity implemente eden bir sınıf olmalı
    {
        //CRUD

        //READ
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//tüm verilerin çekilmesi.çünkü filtre yok
        T Get(Expression<Func<T, bool>> filter);//filtreleme ile veri çekilmesi

        //CREATE
        void Add(T entity);

        //UPDATE
        void Update(T entity);

        //DELETE
        void Delete(T entity);

       
    }
}

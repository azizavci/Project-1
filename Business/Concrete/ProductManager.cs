using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        /// KURAL  :  Bir iş sınıfı başka bir sınıfı new'lemez. Injection yapacağız. 
        /// Peki bu injection'un asıl amacı ne ? Neden yaparız ?
        /// Şimdiki senaryoda memory'de bir List oluşturduk ve ordan işlem yapıyoruz. Yarın Excel'den verilerini çekebilrim yada Veritabanından
        /// yada metin dosyasından. Bunu şuan bilemem şartlar zamanla değişkenlik gösterebilir. Ancak ben bahsettiğim operasyon sınıflarının
        /// (ExcelProductDal, MetinBelgesiProductDal veya DatabaseProductDal gibi) hepsini IProductDal interface'sinden implemente edeceğim.
        /// Tamam hepimizin bildiği gibi interface bir şablon, soyut nesne vs ve implemente eden sınıflar tanımlanan metodları uygulamak zorunda.
        /// Ancak bir diğer özellik olan (aşağıda yaralandığım) interface de bir referans tutucudur. Aşağıdaki gibi bir kullanım yarın sistemi
        /// değiştirdiğimde bana sorun çıkarmayacak. Çünkü o an için hangi veri çekme yöntemini kullanıyorsam onun sınıfını constructor'a göndereceğim.
        /// Yani constructor diyecek ki bana bir IProductDal referansı gönder. Bugün InMemoryProductDal göndeririz yarın ExcelProductDal. İkisinin de 
        /// referansını IProductDal tutacak.

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İŞ KODLARI
            //Get all data
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            //Get data by filter
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            //Get data by filter
            return _productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}

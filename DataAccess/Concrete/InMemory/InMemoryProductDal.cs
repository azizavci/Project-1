using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //cihazın kendi belleğinde çalışıp verileri yöneteceğiz
    //daha sonra entity framework üzerinde
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {
                new Product{ProductId=1, CategoryId=1, ProductName="bardak", UnitsInStock=15, UnitPrice=15},
                new Product{ProductId=2, CategoryId=1, ProductName="kamera", UnitsInStock=3, UnitPrice=500},
                new Product{ProductId=3, CategoryId=2, ProductName="telefon", UnitsInStock=2, UnitPrice=1500},
                new Product{ProductId=4, CategoryId=2, ProductName="klavye", UnitsInStock=65, UnitPrice=150},
                new Product{ProductId=5, CategoryId=2, ProductName="fare", UnitsInStock=1, UnitPrice=85},

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //remove ile direkt olarak silemeyiz çünkü new dediğimizde her seferinde ayrı 
            //bir referans numarası oluşturulur product için 

            //eğer LINQ kullanmazsak bu şekilde silebiliriz
            //listeyi tek tek dolaşıp bir şartla aradığımızı bularak
            //Product productToDelete=null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            _products.Where(p => p.CategoryId == categoryId).ToList();
            return _products;
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün ID sine sahip olan ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

            //biz bu işlemleri bizim için hızlıca yapan mimarileri kullanırız.
            //entity framework, hibernate, dapper gibi
        }
    }
}

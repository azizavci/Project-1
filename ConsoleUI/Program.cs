
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    //SOLID

    //buraya kadar olan kısımda SOLID prensibine ait O harfini irdeledik
    //O : open closed principle
    //yazılıma yeni bir özellik ekleniyorsa yazılım değişmemelidir
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            //get all
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);

            }

            //get all product name of data where id=3
            //foreach (var product in productManager.GetAllByCategoryId(3))
            //{
            //    Console.WriteLine(product.ProductName);

            //}

            //get all product name of where unit price where min>=5 and max<=7
            //foreach (var product in productManager.GetByUnitPrice(5,7))
            //{
            //    Console.WriteLine(product.ProductName);

            //}
        }
    }
}

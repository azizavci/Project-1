using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //bu kullanılacaksa core katmanına bağımlıyız demektir 
    //o yüzden core katmanını referans olarak eklemeliyiz(DataAccess katmanında)
    public interface IProductDal:IEntityRepository<Product>
    {
        

    }
}

//Code refactoring
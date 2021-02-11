using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //burada öyle bir yapı kuralım ki vt ye yeni bir tablo eklenmesi
    //durumunda CRUD vb. işlemler ile tekrar tekrar uğraşmayalım
    //bunun için EF kodları yazacağız.bu yüzden projelerimize EFCore 
    //eklememiz gereklidir.(NUGET)
    //EFCore kullanacağımız tüm projelere bu paketi indir
    //Solution + sağ tık + manage nuget for solution 
    public class EfEntityRepositoryBase<TEntity,TContext>
        where TEntity: class, IEntity,new()
        where TContext: DbContext, new()
    {

    }
}

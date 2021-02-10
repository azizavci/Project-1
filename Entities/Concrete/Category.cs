using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //cıplak class kalmasın: bir sınıfın herhangi bir 
    //implementasyon ya da inheritence bulundurmaması 
    //ilerde problem yaşayabilme olasılığımızı artırır
    //o yüzden bu sınıfları gruplandırmalıyız
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

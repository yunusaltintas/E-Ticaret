using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}

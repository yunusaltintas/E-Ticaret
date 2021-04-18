using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string FilePic { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }

    }
}

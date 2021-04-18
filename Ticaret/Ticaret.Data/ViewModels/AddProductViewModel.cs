using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels
{
   public class AddProductViewModel
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public IFormFile FilePic { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}

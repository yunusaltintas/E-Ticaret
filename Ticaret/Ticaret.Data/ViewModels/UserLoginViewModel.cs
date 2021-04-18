using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ViewModels
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

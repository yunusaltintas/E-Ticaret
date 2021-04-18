using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ResponseModel
{
    public class ReturnModel:Return
    {
        public ReturnModel()
        {
            this.success = true;
        }
        public ReturnModel(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.success = false;
        }
        
    }
}

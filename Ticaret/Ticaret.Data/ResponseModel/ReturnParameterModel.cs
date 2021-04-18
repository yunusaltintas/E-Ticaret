using System;
using System.Collections.Generic;
using System.Text;

namespace Ticaret.Data.ResponseModel
{
    public class ReturnParameterModel<T> : Return
    {
        public T Model { get; set; }

        public ReturnParameterModel(T Model)
        {
            this.success = true;
            this.Model = Model;
        }
        public ReturnParameterModel(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.success = false;

        }
    }
}

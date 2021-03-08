using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationsErrors  {get;set;}
        public ValidationException(ValidationResult validationResault)
        {
            ValidationsErrors = new List<string>();
            foreach (var vallidationError in validationResault.Errors)
            {
                ValidationsErrors.Add(vallidationError.ErrorMessage);
            }
        }
    }

}

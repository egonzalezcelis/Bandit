using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace empleados.Util
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<Error> AllErrors(this ModelStateDictionary modelState)
        {
            var result = from ms in modelState
                         where ms.Value.Errors.Any()
                         let fieldKey = ms.Key
                         let errors = ms.Value.Errors
                         from error in errors
                         select new Error(fieldKey, error.ErrorMessage);

            return result;
        }
    }
}
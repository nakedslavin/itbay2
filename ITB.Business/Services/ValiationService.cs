using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITB.Business.Services
{
    public class ValiationService
    {
        /// <summary>
        /// Validation in the box.
        /// </summary>
        /// <param name="object"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public bool TryValidate(object @object, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );
        }
    }
}

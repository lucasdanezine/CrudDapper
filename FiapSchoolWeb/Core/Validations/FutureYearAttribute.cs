using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapSchoolWeb.Core.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class FutureYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is int))
            {
                return new ValidationResult("Ano inválido.");
            }

            var ano = (int)value;

            if (ano < DateTime.Today.Year)
            {
                return new ValidationResult("O ano da turma não pode ser anterior ao ano atual.");
            }

            return ValidationResult.Success;
        }
    }

}

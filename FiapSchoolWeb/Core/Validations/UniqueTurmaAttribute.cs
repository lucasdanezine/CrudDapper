using FiapSchoolWeb.Core.Models;
using FiapSchoolWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace FiapSchoolWeb.Core.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class UniqueTurmaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var turmaModel = (TurmaModel)validationContext.ObjectInstance;

            var dbContext = (FiapSchoolWebContext)validationContext.GetService(typeof(FiapSchoolWebContext));

            var existingTurma = dbContext.Turmas.FirstOrDefault(t => t.Turma == value.ToString());
            if (existingTurma != null)
            {
                return new ValidationResult("Já existe uma turma com o mesmo nome.");
            }

            return ValidationResult.Success;
        }
    }
}

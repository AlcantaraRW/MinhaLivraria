using Livraria.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Web.Validation
{
    public class ValidarAno : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var livroViewModel = validationContext.ObjectInstance as LivroViewModel;

            if (livroViewModel.AnoPublicacao <= 0)
                return new ValidationResult("O ano deve ser maior que zero.");

            if (livroViewModel.AnoPublicacao > DateTime.Today.Year)
                return new ValidationResult($"O ano especificado é maior que o atual.");

            return ValidationResult.Success;
        }
    }
}
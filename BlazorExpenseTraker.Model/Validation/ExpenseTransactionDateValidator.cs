using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorExpenseTraker.Model.Validation;

public class ExpenseTransactionDateValidator : ValidationAttribute
{
    public int DaysInTheFuture { get; set; }  
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime transactionDate;

        if(DateTime.TryParse(value.ToString(), out transactionDate))
        {
            if(transactionDate == DateTime.MinValue)
            {
                return new ValidationResult($"La fecha no puede estar vacía.",
                    new[] {validationContext.MemberName});
            }
            else if(transactionDate > DateTime.Now.AddDays(DaysInTheFuture))
            {
                return new ValidationResult($"La fecha no puede ser mayor que hoy más {DaysInTheFuture} días.",
                    new[] {validationContext.MemberName});

            }
            return null;
        }
        return new ValidationResult("La fecha no es válida",
            new[] {validationContext.MemberName});
    }
}
